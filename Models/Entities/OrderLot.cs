using System;

namespace OrderKafkaMessageGenerator.Models.Entities
{
    public class OrderLot : Entity<long>
    {
        public string LotId { get; set; }
        public decimal VssPurchaseQuantity { get; set; }
        public decimal LotQuantity { get; set; }
        public decimal? LotPrice { get; set; }
        public DateTimeOffset? LotTradeDate { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdateOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdateBy { get; set; }

        public long OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}