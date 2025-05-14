namespace OrderKafkaMessageGenerator.Models.Entities
{
    public class OrderCommission : Entity<long>
    {
        public decimal? CommissionTypeValue { get; set; }
        public long? CommissionScheduleId { get; set; }
        public string CommissionScheduleName { get; set; }
        public decimal? EstimatedCommission { get; set; }
        public decimal? ActualCommission { get; set; }

        public string EntityId { get; set; }
        public string OfficeId { get; set; }
        public short? EventTypeId { get; set; }
        public short? SecurityTypeId { get; set; }
        public short? SettleLocationId { get; set; }
        public short? OrderTypeId { get; set; }
        public short? TradeCurrencyId { get; set; }
        public short? SettleCurrencyId { get; set; }
        public decimal? AccountValue { get; set; }

        public short CommissionTypeId { get; set; }
        public virtual CommissionType CommissionType { get; set; }
    }
}