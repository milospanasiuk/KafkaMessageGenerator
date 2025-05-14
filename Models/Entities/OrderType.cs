namespace OrderKafkaMessageGenerator.Models.Entities
{
    public class OrderType : Entity<short>
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public bool Default { get; set; }
        public bool HasLimitPrice { get; set; }
        public bool HasStopPrice { get; set; }
    }
}