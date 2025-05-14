namespace OrderKafkaMessageGenerator.Models.Entities
{
    public class SecurityType : Entity<short>
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}