using System;
using Microsoft.Extensions.Hosting;
using MassTransit;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace MassTransitConsumerInjection
{
    public class Worker : BackgroundService
    {
        private static int i;
        private readonly IPublishEndpoint endpoint;
        private readonly ILogger<Worker> logger;

        public Worker(IPublishEndpoint endpoint, ILogger<Worker> logger)
        {
            this.endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (stoppingToken.IsCancellationRequested is false)
            {
                i++;
                var j = i;
                var refund = new PaymentRefund(i.ToString(), "Sender" + i, $"{j++}{j++}{j++}{j++}{j++}{j++}");
                logger.LogInformation($"Publishing message Number {i}.");
                logger.Log(LogLevel.None, "/n");
                await endpoint.Publish<PaymentRefund>(refund);
                await Task.Delay(1000);
            }
        }
    }
}