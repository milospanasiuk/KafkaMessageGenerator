using OrderKafkaMessageGenerator.DTOs;
using OrderKafkaMessageGenerator.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderKafkaMessageGenerator.Interfaces.Business
{
    public interface IKafkaMessageGeneratorBusiness
    {
        Task<IEnumerable<KafkaMessageDTO>> GenerateKafkaMessageAsync(long orderId, KafkaMessageType kafkaMessageType);
    }
}
