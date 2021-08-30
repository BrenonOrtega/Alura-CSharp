using System.Threading.Tasks;
using Contracts.Events;
using MassTransit;
using GreenPipes;
using MassTransit.ConsumeConfigurators;
using MassTransit.Definition;
using Microsoft.Extensions.Logging;

namespace ConsumerOne
{
    public class OrderConsumer : IConsumer<IOrderUsed>
    {
        private readonly ILogger<OrderConsumer> _logger;
        IPublishEndpoint _endpoint;
        public OrderConsumer(ILogger<OrderConsumer> logger, IPublishEndpoint endpoint)
        {
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
            _endpoint = endpoint;
        }

        public Task Consume(ConsumeContext<IOrderUsed> context)
        {
            _logger.LogInformation("Consuming message");

            if (context.Message.Message == string.Empty)
            {
                _logger.LogCritical("empty sender");
                return context.Publish(new { ErrorMessage = "Empty Sender " });
            }

            context.Message.Message = $"Hey I've been consumed correctly at {System.Reflection.Assembly.GetExecutingAssembly()}";
            return _endpoint.Publish(context.Message);
        }
    }

    public class OrderConsumerDefinition : ConsumerDefinition<OrderConsumer>
    {
        protected override void ConfigureConsumer(
            IReceiveEndpointConfigurator endpointConfigurator, 
            IConsumerConfigurator<OrderConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Immediate(30));
        }
    }
}
