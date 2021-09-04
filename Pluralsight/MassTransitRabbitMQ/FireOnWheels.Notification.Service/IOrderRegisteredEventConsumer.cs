using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using FireOnWheels.Shared.Messaging;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace FireOnWheels.Notification.Service
{
    public class IOrderRegisteredEventConsumer : IConsumer<IOrderRegisteredEvents>
    {
        private readonly ILogger<IOrderRegisteredEventConsumer> _logger;
        public IOrderRegisteredEventConsumer(ILogger<IOrderRegisteredEventConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<IOrderRegisteredEvents> context)
        {
            _logger.LogInformation($"{context.Message}");
            return context.Publish<IOrderNotifiedEvent>(new {context.Message.Order});
        }
    }
}
