using OrderKafkaMessageGenerator.Models.Enums;
using System;

namespace OrderKafkaMessageGenerator.Models.Entities
{
    public class OrderHistory : Entity<long>
    {
        public string OriginalClientOrderId { get; set; }
        public string CancelReplaceClientOrderId { get; set; }
        public long OriginalSequenceNumber { get; set; }
        public decimal OrderQuantity { get; set; }
        public short OrderTypeId { get; set; }
        public decimal? LimitPrice { get; set; }
        public decimal? StopPrice { get; set; }
        public decimal? Price { get; set; }
        public bool? IsMarket { get; set; }

        public bool IsSolicited { get; set; }
        public OrderSubmissionStatus OrderStatus { get; set; }
        public long? RevisionNumber { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        public long OrderId { get; set; }
        public virtual Order Order { get; set; }

        public long? OrderCommissionId { get; set; }
        public virtual OrderCommission OrderCommission { get; set; }
    }
}