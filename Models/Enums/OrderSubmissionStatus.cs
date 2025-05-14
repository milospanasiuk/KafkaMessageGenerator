namespace OrderKafkaMessageGenerator.Models.Enums
{
    public enum OrderSubmissionStatus
    {
        PENDING = 0,
        FAILED = 1,
        PENDING_ACK = 2,
        ACKNOWLEDGED = 3,
        PENDING_CANCEL = 4,
        CANCELLED = 5,
        PARTIALLY_FILLED = 6,
        PENDING_REPLACE = 7,
        REPLACED = 8,
        FILLED = 9,
        REJECTED = 10,
    }
}
