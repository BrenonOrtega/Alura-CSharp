using System;
using System.Threading;
using System.Threading.Tasks;
using ArchAspNetDynamoDb.Domain.Models.Entities;
using ArchAspNetDynamoDb.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ArchAspNetDynamoDb.Api
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> logger;
        private readonly IRepository<PaymentRefund> repo;
        private readonly string Operation;


        public Worker(ILogger<Worker> logger, IRepository<PaymentRefund> repo, IConfiguration config)
        {
            this.logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
            this.repo = repo ?? throw new System.ArgumentNullException(nameof(repo));
            Operation = config.GetValue<string>("WorkerOperation");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var i = 1;
            do
            {
                if ("Read".ToLower().Equals(Operation.ToLower()))
                {
                    var payments = await repo.GetByDateAsync(new DateTime(2021, 10, 18));

                    foreach (var payment in payments)
                        logger.LogInformation("{paymentNumber} queried: {payment}", i, payment);
                }
                else
                {
                    logger.LogInformation("Saving a new entity to payment refund database");
                    var paymentRefund = new PaymentRefund() { PaidOutDate = DateTime.Now, PaymentId = Guid.NewGuid().ToString(), Amount = i * 10, Payer = new() { Name = "payer " + i, Document = new string('3', i) } };
                    await repo.SaveAsync(paymentRefund);
                }

                i++;
                await Task.Delay(2000);

            } while (stoppingToken.IsCancellationRequested is false);
        }
    }
}