using OrderKafkaMessageGenerator.Interfaces.Helpers;
using System.Security.Cryptography;

namespace OrderKafkaMessageGenerator.Helpers
{
    public class RandomStringGenerator : IRandomStringGenerator
    {
        private static readonly char[] _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

        public string Generate(int length = 6)
        {
            var result = new char[length];
            using var rng = RandomNumberGenerator.Create();
            var buffer = new byte[1];

            for (int i = 0; i < length; i++)
            {
                rng.GetBytes(buffer);
                result[i] = _chars[buffer[0] % _chars.Length];
            }

            return new string(result);
        }
    }
}
