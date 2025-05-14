namespace OrderKafkaMessageGenerator.Models.Entities
{
    public class SellerCode : Entity<short>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string LocateBroker { get; set; }
    }
}