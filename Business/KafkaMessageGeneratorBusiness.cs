using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderKafkaMessageGenerator.DTOs;
using OrderKafkaMessageGenerator.Interfaces.Business;
using OrderKafkaMessageGenerator.Interfaces.Helpers;
using OrderKafkaMessageGenerator.Models.Entities;
using OrderKafkaMessageGenerator.Models.Enums;
using OrderKafkaMessageGenerator.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderKafkaMessageGenerator.Business
{
    public class KafkaMessageGeneratorBusiness : IKafkaMessageGeneratorBusiness
    {
        private readonly OrdersContext _ordersContext;
        private readonly IRandomStringGenerator _randomStringGenerator;

        public KafkaMessageGeneratorBusiness(OrdersContext ordersContext, IRandomStringGenerator randomStringGenerator)
        {
            _ordersContext = ordersContext;
            _randomStringGenerator = randomStringGenerator;
        }

        public async Task<IEnumerable<KafkaMessageDTO>> GenerateKafkaMessageAsync(long orderId, KafkaMessageType kafkaMessageType)
        {
            var order = await _ordersContext.Orders
                .AsNoTracking()
                .Include(x => x.AccountType)
                .Include(x => x.OrderType)
                .Include(x => x.SecurityType)
                .Include(x => x.TimeInForce)
                .Include(x => x.Side)
                .Include(x => x.OrderOptions)
                    .ThenInclude(x => x.Side)
                .SingleOrDefaultAsync(x => x.Id == orderId);

            if (order == null)
            {
                return new List<KafkaMessageDTO>()
                {
                    new KafkaMessageDTO
                    {
                        ErrorMessage = $"Order with Id: [{orderId}] not found",
                    },
                };
            }

            KafkaMessageDTO kafkaMessage;
            var result = new List<KafkaMessageDTO>();

            if (order.OrderOptions.Any())
            {
                foreach (var orderOption in order.OrderOptions)
                {
                    kafkaMessage = await GetKafkaMessageAsync(order, orderOption, kafkaMessageType);
                    
                    result.Add(kafkaMessage);
                }

                return result;
            }

            kafkaMessage = await GetKafkaMessageAsync(order, null, kafkaMessageType);

            result.Add(kafkaMessage);

            return result;
        }

        private async Task<KafkaMessageDTO> GetKafkaMessageAsync(Order order, OrderOption orderOption, KafkaMessageType kafkaMessageType)
        {
            switch (kafkaMessageType)
            {
                case KafkaMessageType.ACK:
                    return GenerateAcknowledgeKafkaMessage(order, orderOption);
                case KafkaMessageType.REJECT:
                    return await GenerateRejectKafkaMessageAsync(order, orderOption);
                case KafkaMessageType.PENDING_CANCEL:
                    return await GeneratePendingCancelKafkaMessageAsync(order, orderOption);
                case KafkaMessageType.CANCEL:
                    return await GenerateCancelKafkaMessageAsync(order, orderOption);
                case KafkaMessageType.PENDING_REPLACE:
                    return await GeneratePendingReplaceKafkaMessageAsync(order, orderOption);
                case KafkaMessageType.REPLACE:
                    return await GenerateReplaceKafkaMessageAsync(order, orderOption);
                case KafkaMessageType.PARTIAL_FILL:
                    return GenerateKafkaPartialFillMessage(order, orderOption);
                case KafkaMessageType.FILL:
                    return GenerateKafkaFillMessage(order, orderOption);
                default:
                    return GenerateAcknowledgeKafkaMessage(order, orderOption);
            }
        }

        private KafkaMessageDTO GenerateAcknowledgeKafkaMessage(Order order, OrderOption orderOption)
        {
            var kafkaMessage = GenerateDefaultKafkaMessage(order, orderOption, "0");

            kafkaMessage.CumQty = "0";

            kafkaMessage.ClientOrderID = order.ClientOrderId;
            kafkaMessage.LeavesQty = kafkaMessage.OrderQuantity;

            return kafkaMessage;
        }

        private async Task<KafkaMessageDTO> GenerateRejectKafkaMessageAsync(Order order, OrderOption orderOption)
        {
            var kafkaMessage = GenerateDefaultKafkaMessage(order, orderOption, "8");

            if (order.OrderStatus == OrderSubmissionStatus.PENDING_ACK)
            {
                kafkaMessage.ClientOrderID = order.ClientOrderId;
            }
            else if (order.OrderStatus == OrderSubmissionStatus.PENDING_CANCEL)
            {
                var cancelOrder = await _ordersContext.Orders.SingleOrDefaultAsync(x => x.OriginalClientOrderId == order.ClientOrderId);
                if (cancelOrder == null)
                {
                    return new KafkaMessageDTO
                    {
                        ErrorMessage = $"Order with Id: [{order.Id}] does not have cancel order to reject it.",
                    };
                }

                kafkaMessage.ClientOrderID = cancelOrder.ClientOrderId;
                kafkaMessage.OriginalClientOrderID = cancelOrder.OriginalClientOrderId;
            }
            else if (order.OrderStatus == OrderSubmissionStatus.PENDING_REPLACE)
            {
                var cancelReplaceOrder = await _ordersContext.OrderHistories.OrderBy(x => x.Id)
                    .LastOrDefaultAsync(x => x.OrderStatus == OrderSubmissionStatus.PENDING_REPLACE);

                if (cancelReplaceOrder == null)
                {
                    return new KafkaMessageDTO
                    {
                        ErrorMessage = $"Order with Id: [{order.Id}] does not have cancel replace in PENDING_REPLACE state to reject it.",
                    };
                }

                kafkaMessage.ClientOrderID = cancelReplaceOrder.CancelReplaceClientOrderId;
            }

            return kafkaMessage;
        }

        private async Task<KafkaMessageDTO> GeneratePendingCancelKafkaMessageAsync(Order order, OrderOption orderOption)
        {
            var kafkaMessage = GenerateDefaultKafkaMessage(order, orderOption, "6");

            var cancelOrder = await _ordersContext.Orders.SingleOrDefaultAsync(x => x.OriginalClientOrderId == order.ClientOrderId);
            if (cancelOrder == null)
            {
                return new KafkaMessageDTO
                {
                    ErrorMessage = $"Order with Id: [{order.Id}] does not have cancel order.",
                };
            }

            kafkaMessage.ClientOrderID = cancelOrder.ClientOrderId;
            kafkaMessage.OriginalClientOrderID = cancelOrder.OriginalClientOrderId;

            return kafkaMessage;
        }

        private async Task<KafkaMessageDTO> GenerateCancelKafkaMessageAsync(Order order, OrderOption orderOption)
        {
            var kafkaMessage = GenerateDefaultKafkaMessage(order, orderOption, "4");

            var cancelOrder = await _ordersContext.Orders.SingleOrDefaultAsync(x => x.OriginalClientOrderId == order.ClientOrderId);
            if (cancelOrder == null)
            {
                return new KafkaMessageDTO
                {
                    ErrorMessage = $"Order with Id: [{order.Id}] does not have cancel order.",
                };
            }

            kafkaMessage.ClientOrderID = cancelOrder.ClientOrderId;
            kafkaMessage.OriginalClientOrderID = cancelOrder.OriginalClientOrderId;

            return kafkaMessage;
        }

        private async Task<KafkaMessageDTO> GeneratePendingReplaceKafkaMessageAsync(Order order, OrderOption orderOption)
        {
            var kafkaMessage = GenerateDefaultKafkaMessage(order, orderOption, "E");

            var pendingReplaceOrder = await _ordersContext.OrderHistories.OrderBy(x => x.Id)
                    .LastOrDefaultAsync(x => x.OrderStatus == OrderSubmissionStatus.PENDING_REPLACE);

            if (pendingReplaceOrder == null)
            {
                return new KafkaMessageDTO
                {
                    ErrorMessage = $"Order with Id: [{order.Id}] does not have cancel replace in PENDING_REPLACE.",
                };
            }

            kafkaMessage.ClientOrderID = pendingReplaceOrder.CancelReplaceClientOrderId;

            return kafkaMessage;
        }

        private async Task<KafkaMessageDTO> GenerateReplaceKafkaMessageAsync(Order order, OrderOption orderOption)
        {
            var kafkaMessage = GenerateDefaultKafkaMessage(order, orderOption, "5");

            var pendingReplaceOrder = await _ordersContext.OrderHistories.OrderBy(x => x.Id)
                    .LastOrDefaultAsync(x => x.OrderStatus == OrderSubmissionStatus.PENDING_REPLACE);

            if (pendingReplaceOrder == null)
            {
                return new KafkaMessageDTO
                {
                    ErrorMessage = $"Order with Id: [{order.Id}] does not have cancel replace in PENDING_REPLACE.",
                };
            }

            kafkaMessage.ClientOrderID = pendingReplaceOrder.CancelReplaceClientOrderId;

            return kafkaMessage;
        }

        private KafkaMessageDTO GenerateKafkaPartialFillMessage(Order order, OrderOption orderOption)
        {
            var kafkaMessage = GenerateDefaultKafkaMessage(order, orderOption, "1");

            if (order.RevisionNumber.HasValue)
            {
                kafkaMessage.ClientOrderID = $"{order.ClientOrderId}-{order.RevisionNumber.Value}";
            }
            else
            {
                kafkaMessage.ClientOrderID = order.ClientOrderId;
            }

            var price = GetAveragePricePerSymbol(order.Symbol);

            kafkaMessage.LastFill = 1;
            kafkaMessage.LastPrice = price;
            kafkaMessage.AveragePrice = price.ToString();
            kafkaMessage.LeavesQty = (order.LeavesQuantity.GetValueOrDefault() - 1).ToString();
            kafkaMessage.CumQty = (order.ExecutedQuantity.GetValueOrDefault() + 1).ToString();

            return kafkaMessage;
        }

        private KafkaMessageDTO GenerateKafkaFillMessage(Order order, OrderOption orderOption)
        {
            var kafkaMessage = GenerateDefaultKafkaMessage(order, orderOption, "2");

            if (order.RevisionNumber.HasValue)
            {
                kafkaMessage.ClientOrderID = $"{order.ClientOrderId}-{order.RevisionNumber.Value}";
            }
            else
            {
                kafkaMessage.ClientOrderID = order.ClientOrderId;
            }

            var price = GetAveragePricePerSymbol(order.Symbol);

            if (order.Product != Product.MLEG_OPTIONS)
            {
                kafkaMessage.LastFill = order.OrderQuantity.GetValueOrDefault() - order.ExecutedQuantity.GetValueOrDefault();
                kafkaMessage.LastPrice = price;
                kafkaMessage.AveragePrice = price.ToString();
                kafkaMessage.LeavesQty = "0";
                kafkaMessage.CumQty = order.OrderQuantity.GetValueOrDefault().ToString();
            }
            else
            {
                // todo for MLEG from orderOption -> same for partial fill
                kafkaMessage.LastFill = order.OrderQuantity.GetValueOrDefault() - order.ExecutedQuantity.GetValueOrDefault();
                kafkaMessage.LastPrice = price;
                kafkaMessage.AveragePrice = price.ToString();
                kafkaMessage.LeavesQty = "0";
                kafkaMessage.CumQty = order.OrderQuantity.GetValueOrDefault().ToString();
            }

            return kafkaMessage;
        }

        private KafkaMessageDTO GenerateDefaultKafkaMessage(Order order, OrderOption orderOption, string execType)
        {
            var randomString = _randomStringGenerator.Generate();

            var message = new KafkaMessageDTO
            {
                Account = $"{order.AccountNumber}{order.AccountType.Code}",
                ExecID = $"{order.OrderSequenceNumber}-{execType}-{randomString}",
                ExecType = execType,
                OrdStatus = execType,
                SequenceNumber = order.OrderSequenceNumber,
                OrderID = order.OrderSequenceNumber.ToString(),
                OrderQuantity = order.OrderQuantity.GetValueOrDefault().ToString(),
                OrderType = order.OrderType.Code,
                SecurityType = order.SecurityType.Code,
                Side = int.Parse(order.Side.Code),
                Symbol = order.Symbol,
                TimeInForce = int.Parse(order.TimeInForce.Code),
            };

            if (orderOption != null)
            {
                message.MaturityMonthYear = orderOption.MaturityYearMonth;
                message.MaturityDay = orderOption.MaturityDay;
                message.PutOrCall = orderOption.PutCall;
                message.StrikePrice = orderOption.StrikePrice.GetValueOrDefault().ToString();
                message.OpenClose = orderOption.OpenClose;
                message.Side = int.Parse(orderOption.Side.Code);
                message.OrderQuantity = orderOption.OrderQuantity.GetValueOrDefault().ToString();

                if (order.Product == Product.MLEG_OPTIONS)
                {
                    message.NoLegs = new KafkaMessageNumberOfLegs
                    {
                        LegRefID = orderOption.LegNumber.ToString(),
                    };

                    message.Price = order.Price;
                }

                message.SecurityType = orderOption.LegProduct == Product.OPTIONS ? "OPT" : "CS";
            }

            return message;
        }

        private decimal GetAveragePricePerSymbol(string symbol)
        {
            switch (symbol.ToUpper())
            {
                case "MSFT":
                    return 400.0m;
                case "AAPL":
                    return 240.0m;
                default:
                    return 10.0m;
            }
        }
    }
}
