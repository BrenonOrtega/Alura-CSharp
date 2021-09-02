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
            File.WriteAllText(Path.Join(AppContext.BaseDirectory, "../../Notification.json"), JsonSerializer.Serialize<IOrderRegisteredEvents>(context.Message));
            context.Publish<IOrderNotifiedEvent>(new {context.Message.Order});
            return Task.CompletedTask;
        }
    }
}
