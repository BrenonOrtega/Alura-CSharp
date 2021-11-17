using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DistributedLock.Commons;
using RedLockNet;

namespace ConsumerTwo
{
    public class Worker : BackgroundService
    {

        private readonly ILogger<Worker> _logger;
        private IRedLock _redLock;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                await using (_redLock = await RedLockCreator.GetRedLockAsync())
                {
                    await Task.Delay(3000, stoppingToken);
                    _logger.LogInformation("Worker {consumer} running at: {time}", nameof(ConsumerTwo), DateTimeOffset.Now);

                    if (!_redLock.IsAcquired)
                        continue;

                    _logger.LogInformation("RedLock is Aquired by {consumer}", nameof(ConsumerTwo));
                }

            } while (stoppingToken.IsCancellationRequested is false);
        }
    }
}
