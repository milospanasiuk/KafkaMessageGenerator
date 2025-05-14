namespace OrderKafkaMessageGenerator.Models.Entities
{
    public class ExecutionDestination : Entity<short>
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public bool Default { get; set; }
    }
}