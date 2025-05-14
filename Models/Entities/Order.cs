using System.Collections.Generic;
using System.Text.Json.Serialization;
using System;
using OrderKafkaMessageGenerator.Models.Enums;

namespace OrderKafkaMessageGenerator.Models.Entities
{
    public class Order : Entity<long>
    {
        public string ClientOrderId { get; set; }
        public string OriginalClientOrderId { get; set; }
        public long AccountId { get; set; }
        public string AccountNumber { get; set; }
        public string ClientId { get; set; }
        public string Source { get; set; }
        public string Trader { get; set; }
        public string Symbol { get; set; }
        public string PreferredSymbolPrefix { get; set; }
        public string PreferredSymbolSuffix { get; set; }
        public string SymbolDescription { get; set; }
        public string SecurityId { get; set; }
        public decimal? OrderQuantity { get; set; }
        public decimal? LimitPrice { get; set; }
        public decimal? StopPrice { get; set; }
        public decimal? Price { get; set; } // Multileg
        public DateTimeOffset TransactionTime { get; set; }
        public string ExecutionDestination { get; set; }
        public string Currency { get; set; }
        public string MessageType { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdateOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdateBy { get; set; }
        public string MiscText { get; set; }
        public decimal? ExecutedQuantity { get; set; }
        public decimal? LeavesQuantity { get; set; }
        public decimal? AveragePrice { get; set; }
        public bool IsSolicited { get; set; }
        public OrderSubmissionStatus OrderStatus { get; set; }
        public DateTimeOffset? ExpireDate { get; set; }
        public string TTORep { get; set; }
        public string RepCode { get; set; }
        public string Cusip { get; set; }
        public bool? Affiliation { get; set; }
        public bool? Discretion { get; set; }
        public bool? TimeAndPriceDiscretion { get; set; }
        public bool? VsPurchase { get; set; }
        public bool? IsMarket { get; set; }
        public Product Product { get; set; }
        public DateTimeOffset? SettleDate { get; set; }
        public decimal? ExecutedPriceOfLastFill { get; set; }
        public string ExchangeOfLastFill { get; set; }
        public long? RevisionNumber { get; set; }
        public OrderActive? Active { get; set; }

        public string LocateBroker { get; set; }
        public string CountryOfDomicile { get; set; }
        public string OrderLotMethodology { get; set; }

        public short? AccountTypeId { get; set; }
        public virtual AccountType AccountType { get; set; }

        public short? SideId { get; set; }
        public virtual Side Side { get; set; }

        public short? HandlingInstructionId { get; set; }
        public virtual HandlingInstruction HandlingInstruction { get; set; }

        public short? IdSourceId { get; set; }
        public virtual IdSource IdSource { get; set; }

        public short? OrderTypeId { get; set; }
        public virtual OrderType OrderType { get; set; }

        public short? OrderCapacityId { get; set; }
        public virtual OrderCapacity OrderCapacity { get; set; }

        public short? TimeInForceId { get; set; }
        public virtual TimeInForce TimeInForce { get; set; }

        public short? SettlementTypeId { get; set; }
        public virtual SettlementType SettlementType { get; set; }

        public short? SellerCodeId { get; set; }
        public virtual SellerCode SellerCode { get; set; }

        public short? SpecialInstructionId { get; set; }
        public virtual SpecialInstruction SpecialInstruction { get; set; }

        public short? SecurityTypeId { get; set; }
        public virtual SecurityType SecurityType { get; set; }

        public long? OrderCommissionId { get; set; }
        public virtual OrderCommission OrderCommission { get; set; }

        public long OrderSequenceNumber { get; set; }

        public OrderChannel? Channel { get; set; }

        public string SterlingOrderId { get; set; }


        [JsonIgnore]
        public virtual IEnumerable<OrderLot> OrderLots { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<OrderOption> OrderOptions { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<TradeBooking> TradeBookings { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<OrderHistory> OrderHistories { get; set; }
    }
}