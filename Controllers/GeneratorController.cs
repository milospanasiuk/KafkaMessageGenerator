using Microsoft.AspNetCore.Mvc;
using OrderKafkaMessageGenerator.Interfaces.Business;
using OrderKafkaMessageGenerator.Models.Enums;
using System.Threading.Tasks;

namespace OrderKafkaMessageGenerator.Controllers
{
    [Route("generatorapi/[Controller]/{orderId}")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class GeneratorController : ControllerBase
    {
        private readonly IKafkaMessageGeneratorBusiness _kafkaMessageGeneratorBusiness;

        public GeneratorController(IKafkaMessageGeneratorBusiness kafkaMessageGeneratorBusiness)
        {
            _kafkaMessageGeneratorBusiness = kafkaMessageGeneratorBusiness;
        }

        [HttpPost("acknowledge")]
        public async Task<IActionResult> GenerateAcknowledgeKafkaMessageAsync([FromRoute] long orderId)
        {
            var result = await _kafkaMessageGeneratorBusiness.GenerateKafkaMessageAsync(orderId, KafkaMessageType.ACK);

            return Ok(result);
        }

        [HttpPost("reject")]
        public async Task<IActionResult> GenerateRejectKafkaMessageAsync([FromRoute] long orderId)
        {
            var result = await _kafkaMessageGeneratorBusiness.GenerateKafkaMessageAsync(orderId, KafkaMessageType.REJECT);

            return Ok(result);
        }

        [HttpPost("pending-cancel")]
        public async Task<IActionResult> GeneratePendingCancelKafkaMessageAsync([FromRoute] long orderId)
        {
            var result = await _kafkaMessageGeneratorBusiness.GenerateKafkaMessageAsync(orderId, KafkaMessageType.PENDING_CANCEL);

            return Ok(result);
        }

        [HttpPost("cancel")]
        public async Task<IActionResult> GenerateCancelKafkaMessageAsync([FromRoute] long orderId)
        {
            var result = await _kafkaMessageGeneratorBusiness.GenerateKafkaMessageAsync(orderId, KafkaMessageType.CANCEL);

            return Ok(result);
        }

        [HttpPost("pending-replace")]
        public async Task<IActionResult> GeneratePendingReplaceKafkaMessageAsync([FromRoute] long orderId)
        {
            var result = await _kafkaMessageGeneratorBusiness.GenerateKafkaMessageAsync(orderId, KafkaMessageType.PENDING_REPLACE);

            return Ok(result);
        }

        [HttpPost("replace")]
        public async Task<IActionResult> GenerateReplaceKafkaMessageAsync([FromRoute] long orderId)
        {
            var result = await _kafkaMessageGeneratorBusiness.GenerateKafkaMessageAsync(orderId, KafkaMessageType.REPLACE);

            return Ok(result);
        }

        [HttpPost("partial-fill")]
        public async Task<IActionResult> GeneratePartialFillKafkaMessageAsync([FromRoute] long orderId)
        {
            var result = await _kafkaMessageGeneratorBusiness.GenerateKafkaMessageAsync(orderId, KafkaMessageType.PARTIAL_FILL);

            return Ok(result);
        }

        [HttpPost("fill")]
        public async Task<IActionResult> GenerateFillKafkaMessageAsync([FromRoute] long orderId)
        {
            var result = await _kafkaMessageGeneratorBusiness.GenerateKafkaMessageAsync(orderId, KafkaMessageType.FILL);

            return Ok(result);
        }

        [HttpPost("multiple-partial-fill-and-fill")]
        public async Task<IActionResult> GenerateMultiplePartialFillAndFillKafkaMessageAsync([FromRoute] long orderId)
        {
            var result = await _kafkaMessageGeneratorBusiness.GenerateKafkaMessageAsync(orderId, KafkaMessageType.MULTI_PARTIAL_FILL_AND_FILL);

            return Ok(result);
        }
    }
}
