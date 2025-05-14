namespace OrderKafkaMessageGenerator.Models.Enums
{
    public enum BookingStatus
    {
        MANUALLY_BOOKED = -3,
        REPLACED = -2,
        NOT_SENT = -1,

        PENDING = 0,
        BOOKED = 4,
        REJECTED = 5,
    }
}
