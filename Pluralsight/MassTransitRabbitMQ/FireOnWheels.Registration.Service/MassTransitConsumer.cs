using System;
using System.Threading.Tasks;
using FireOnWheels.Shared.Messaging;
using MassTransit;

namespace FireOnWheels.Registration.Service
{
    public class MassTransitConsumer : IConsumer<IOrderRegistrationCommand>
    {
        public Task Consume(ConsumeContext<IOrderRegistrationCommand> context)
        {
            var command = context.Message;
            Console.WriteLine($"{command.Id} {command.Order.Receiver} {command.Order.Sender}");

            return Task.CompletedTask;
        }
    }
}