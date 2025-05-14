using OrderKafkaMessageGenerator.Models.Enums;
using System;

namespace OrderKafkaMessageGenerator.Models.Entities
{
    public class TradeBookingAudit : Entity<long>
    {
        public string ExecutionId { get; set; }
        public string TradeBookingMessage { get; set; }
        public string P3TradeConfirmationNumber { get; set; }
        public string RejectReason { get; set; }
        public TradeBookingChannel Channel { get; set; }
        public string CreatedBy { get; set; }
        public Guid? TraceOrderId { get; set; }
    }
}