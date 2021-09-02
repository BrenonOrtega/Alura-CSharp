using System;
using System.IO;
using System.Threading.Tasks;
using FireOnWheels.Shared.Messaging;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace FireOnWheels.Registration.Service
{
    public class OrderRegistrationConsumer : IConsumer<IOrderRegistrationCommand>
    {
        private readonly ILogger<OrderRegistrationConsumer> _logger;

        public OrderRegistrationConsumer(ILogger<OrderRegistrationConsumer> logger)
        {
            _logger = logger;
        }
        public Task Consume(ConsumeContext<IOrderRegistrationCommand> context)
        {
            var command = context.Message;
            File.WriteAllText(Path.Join(AppContext.BaseDirectory, "..\\..\\RegistrationFile.txt"),
                $"Message consumed { context.CorrelationId } - Contents: Id: { command.Id } Order: { command.Order.Id }" +
                $"Sender { command.Order.Sender.Name } - Address { command.Order.Sender.Address } - { command.Order.Sender.City } " +
                $"Receiver { command.Order.Receiver.Name } - Address { command.Order.Receiver.Address } - { command.Order.Receiver.City } "
            );

            _logger.LogInformation(context.Message.ToString());
            return context.Send<IOrderRegisteredEvents>(new{ Id=command.Id, Order=command.Order });
        }
    }
}