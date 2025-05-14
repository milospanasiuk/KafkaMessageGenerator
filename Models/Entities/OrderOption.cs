using OrderKafkaMessageGenerator.Models.Enums;

namespace OrderKafkaMessageGenerator.Models.Entities
{
    public class OrderOption : Entity<long>
    {
        public string MaturityYearMonth { get; set; }
        public string MaturityDay { get; set; }
        public string PutCall { get; set; }
        public decimal? StrikePrice { get; set; }
        public string OpenClose { get; set; }
        public string OSISymbol { get; set; }
        public short LegNumber { get; set; }
        public decimal? OrderQuantity { get; set; }
        public decimal? Ratio { get; set; }
        public Product LegProduct { get; set; }

        //Updated by Execution Report
        public OrderSubmissionStatus OrderStatus { get; set; }
        public decimal? ExecutedQuantity { get; set; }
        public decimal? LeavesQuantity { get; set; }
        public decimal? AveragePrice { get; set; }
        public decimal? ExecutedPriceOfLastFill { get; set; }
        public string ExchangeOfLastFill { get; set; }

        public long? OrderCommissionId { get; set; }
        public virtual OrderCommission OrderCommission { get; set; }

        public short SideId { get; set; }
        public virtual Side Side { get; set; }

        public short? SellerCodeId { get; set; }
        public virtual SellerCode SellerCode { get; set; }

        public long OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}