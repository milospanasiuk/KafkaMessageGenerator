namespace OrderKafkaMessageGenerator.Models.Entities
{
    public class OrderCapacity : Entity<short>
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}