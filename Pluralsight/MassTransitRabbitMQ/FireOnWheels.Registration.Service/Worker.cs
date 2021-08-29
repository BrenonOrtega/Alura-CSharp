using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using FireOnWheels.Shared.Messaging;
using System.Text.Json;
using System.Text;
using static FireOnWheels.Shared.Messaging.RabbitMqConstants
;
namespace FireOnWheels.Registration.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConnectionFactory _factory;
        private readonly IConnection _connection;
        private readonly IModel _channel;


        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;

            _factory = new ConnectionFactory() { Uri = new Uri(RabbitMqUri) };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(RegisterOderQueue, true,false, false, null);
            _channel.QueueBind(RegisterOderQueue, RegisterOderExchange, "", null);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (x, y) =>
            {
                var body = y.Body.ToArray();
                var registration = JsonSerializer.Deserialize<OrderRegistration>(body);

                Console.WriteLine($"Order Registration { registration.Id }: { registration.Order }");
            };
        }
    }
}
