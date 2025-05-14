namespace OrderKafkaMessageGenerator.Models.Entities
{
    public class HandlingInstruction : Entity<short>
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}