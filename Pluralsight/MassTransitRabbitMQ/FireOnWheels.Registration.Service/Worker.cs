using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MassTransit;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using FireOnWheels.Shared.Messaging;
using System.Text.Json;
using FireOnWheels.Shared.Messaging.Converters;
using FireOnWheels.Shared.Messaging.Infra;
using static FireOnWheels.Shared.Messaging.RabbitMqConstants;
using mt = FireOnWheels.Shared.Messaging.MassTransitRabbitMqConstants;
namespace FireOnWheels.Registration.Service
{
    public class Worker : BackgroundService
    {
        private ILogger<Worker> _logger;
        private IConnectionFactory _factory;
        private IConnection _connection;
        private IModel _channel;
        private IBusControl bus;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;

            UseRabbitMqConsumer();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);

            OrderRegistration registration;
            consumer.Received += async (sender, eventArgs) =>
            {

                var contentArray = eventArgs.Body.ToArray();
                var options = new JsonSerializerOptions();
                options.Converters.Add(new IOrderConverter());

                registration = JsonSerializer.Deserialize<OrderRegistration>(contentArray, options);

                Console.WriteLine($"Order Registration { registration?.Id }: { registration?.Order }");
                _channel.BasicAck(1, false);
                await Task.CompletedTask;
            };

            _channel.BasicConsume(RegisterOderQueue, false, consumer);
            await Task.CompletedTask;

        }

        private void UseRabbitMqConsumer()
        {
            _factory = new ConnectionFactory() { Uri = new Uri(RabbitMqUri), DispatchConsumersAsync = true };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(RegisterOderQueue, true, false, false, null);
            _channel.QueueBind(RegisterOderQueue, RegisterOderExchange, "", null);
            _channel.BasicQos(0, 1, false);
        }
        
        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
