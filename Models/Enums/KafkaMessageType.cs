namespace OrderKafkaMessageGenerator.Models.Enums
{
    public enum KafkaMessageType
    {
        ACK = 0,
        PENDING_REPLACE = 1,
        REPLACE = 2,
        PENDING_CANCEL = 3,
        CANCEL = 4,
        PARTIAL_FILL = 5,
        FILL = 6,
        REJECT = 7,
        MULTI_PARTIAL_FILL_AND_FILL = 8,
    }
}
