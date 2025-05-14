namespace OrderKafkaMessageGenerator.Models.Entities
{
    public class IdSource : Entity<short>
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}