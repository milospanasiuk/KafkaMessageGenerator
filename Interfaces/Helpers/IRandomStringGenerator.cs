namespace OrderKafkaMessageGenerator.Interfaces.Helpers
{
    public interface IRandomStringGenerator
    {
        string Generate(int length = 6);
    }
}
