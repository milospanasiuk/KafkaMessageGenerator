namespace OrderKafkaMessageGenerator.Models.Entities
{
    public class SpecialInstruction : Entity<short>
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public short? ExecutionDestinationId { get; set; }
        public virtual ExecutionDestination ExecutionDestination { get; set; }
    }
}