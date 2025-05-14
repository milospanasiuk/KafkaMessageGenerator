namespace OrderKafkaMessageGenerator.Models.Entities
{
    public class TimeInForce : Entity<short>
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public bool Default { get; set; }
        public bool DateRequired { get; set; }
    }
}