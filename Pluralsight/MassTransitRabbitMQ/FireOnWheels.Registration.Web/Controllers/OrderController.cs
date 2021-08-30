using System;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FireOnWheels.Registration.Web.Dtos;
using FireOnWheels.Shared.Messaging;
using FireOnWheels.Shared.Messaging.Infra;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using static FireOnWheels.Shared.Messaging.RabbitMqConstants;
using mt = FireOnWheels.Shared.Messaging.MassTransitRabbitMqConstants;

namespace FireOnWheels.Registration.Web.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IPublishEndpoint _endpoint;

        public OrdersController(IPublishEndpoint endpoint)
        {
            _endpoint = endpoint;
        }

        [HttpGet]
        public async Task<IActionResult> Index() =>
            await Task.FromResult(new ObjectResult(new { StatusCode = HttpStatusCode.OK, Order = typeof(OrderDto).GetProperties() }));

        [HttpPost, Route("rabbitmq")]
        public async Task<IActionResult> Post([FromBody] OrderDto order)
        {
            var registrationOrder = new OrderRegistrationCommand(order);
            var serializedOrder = JsonSerializer.Serialize<OrderRegistrationCommand>(registrationOrder);
            var messageBody = Encoding.UTF8.GetBytes(serializedOrder);

            var factory = new ConnectionFactory() { Uri = new System.Uri(RabbitMqUri) };
            var conn = factory.CreateConnection();

            var model = conn.CreateModel();

            model.ExchangeDeclare(RegisterOderExchange, ExchangeType.Fanout, true, false, null);
            model.BasicPublish(exchange: RegisterOderExchange,
                routingKey: "",
                mandatory: false,
                basicProperties: null,
                body: messageBody);

            return await Task.FromResult(Ok(order));
        }

        [HttpPost, Route("masstransit")]
        public async Task<IActionResult> PostWithMassTransit([FromBody] OrderDto order)
        {
            var publishUri = new Uri(mt.RabbitMqUri + mt.OrderRegisteredQueue);
            var command = new OrderRegistrationCommand(order);
            await _endpoint.Publish<IOrderRegistrationCommand>(command);

            return Accepted(command);
        }
    }
}