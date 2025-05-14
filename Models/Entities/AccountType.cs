namespace OrderKafkaMessageGenerator.Models.Entities
{
    public class AccountType : Entity<short>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Margin { get; set; }
        public string Code { get; set; }
    }
}