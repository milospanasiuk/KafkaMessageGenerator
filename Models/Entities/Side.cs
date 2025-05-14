namespace OrderKafkaMessageGenerator.Models.Entities
{
    public class Side : Entity<short>
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}