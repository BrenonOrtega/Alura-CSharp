using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FireOnWheels.Shared.Messaging;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using static FireOnWheels.Shared.Messaging.RabbitMqConstants;

namespace FireOnWheels.Registration.Web.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class OrdersController : ControllerBase
    {
        public OrdersController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index() =>
            await Task.FromResult(new ObjectResult(new { StatusCode = HttpStatusCode.OK, Message = "" }));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderDto order)
        {
            var serializedOrder = JsonSerializer.Serialize(order, typeof(OrderDto), new JsonSerializerOptions() { WriteIndented = true });
            var messageBody = Encoding.UTF8.GetBytes(serializedOrder);

            var factory = new ConnectionFactory() { Uri = new System.Uri(RabbitMqUri) };
            var conn = factory.CreateConnection();

            var model = conn.CreateModel();

            model.ExchangeDeclare(RegisterOderExchange, ExchangeType.Direct, true, false, null);
            model.BasicPublish(exchange: RegisterOderExchange,
                routingKey: RegisterOderQueue,
                mandatory: false,
                basicProperties: null,
                body: messageBody);

            return Ok(order);
        }
    }
}