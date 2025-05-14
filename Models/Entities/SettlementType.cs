namespace OrderKafkaMessageGenerator.Models.Entities
{
    public class SettlementType : Entity<short>
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public bool Default { get; set; }
        public short? ExecutionDestinationId { get; set; }
        public virtual ExecutionDestination ExecutionDestination { get; set; }
    }
}