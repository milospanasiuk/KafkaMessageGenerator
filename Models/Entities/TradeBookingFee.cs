using System.Text.Json.Serialization;

namespace OrderKafkaMessageGenerator.Models.Entities
{
    public class TradeBookingFee : Entity<long>
    {
        public string FeeTypeName { get; set; }
        public decimal Fee { get; set; }
        public string Currency { get; set; }
        public string P3Code { get; set; }
        public long TradeBookingId { get; set; }

        [JsonIgnore]
        public virtual TradeBooking TradeBooking { get; set; }
    }
}