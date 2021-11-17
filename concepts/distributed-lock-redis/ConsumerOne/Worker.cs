using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DistributedLock.Commons;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RedLockNet;
using RedLockNet.SERedis;

namespace ConsumerOne
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IRedLock _redLock;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            _redLock = RedLockCreator.GetRedLockFactory().CreateLock(RedLockCreator.MyLockedResource, TimeSpan.FromSeconds(3));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                _logger.LogInformation("Worker {consumer} running at: {time}", nameof(ConsumerOne), DateTimeOffset.Now);

                if (!_redLock.IsAcquired)
                {
                    await Task.Delay(500);
                    continue;
                }

                _logger.LogInformation("RedLock is Aquired by {consumer}", nameof(ConsumerOne));

            } while (stoppingToken.IsCancellationRequested is false);
        }
    }
}
