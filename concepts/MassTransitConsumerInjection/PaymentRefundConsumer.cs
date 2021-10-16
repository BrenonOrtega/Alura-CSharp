using System;
using MassTransit;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace MassTransitConsumerInjection
{
    public class PaymentRefundConsumer : IPaymentRefundConsumer
    {
        private readonly ILogger<PaymentRefundConsumer> logger;

        public PaymentRefundConsumer(ILogger<PaymentRefundConsumer> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task Consume(ConsumeContext<PaymentRefund> context)
        {
            var message = context.Message;
            logger.LogInformation($"Consuming Message - Id:{context.MessageId}");
            logger.LogInformation($"Message: { JsonSerializer.Serialize(message, new JsonSerializerOptions() { WriteIndented = true, IncludeFields = true }) }");
            return Task.CompletedTask;
        }
    }
}