namespace OrderKafkaMessageGenerator.Models.Entities
{
    public class CommissionType : Entity<short>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}