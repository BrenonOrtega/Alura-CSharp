using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RedLockNet;

namespace SimpleLock.Processors
{
    internal class RedLockResourceProcessor : IResourceProcessor, IAsyncDisposable
    {
        private readonly ILogger<RedLockResourceProcessor> logger;
        private readonly IRedLock redlock;
        private readonly IResourceProcessor next;

        public RedLockResourceProcessor(ILogger<RedLockResourceProcessor> logger, IRedLock redlock, IResourceProcessor next, IRedLockConfig redLockConfig)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.redlock = redlock ?? throw new ArgumentNullException(nameof(redlock));
            this.next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public ValueTask DisposeAsync() => redlock.DisposeAsync();

        public Task<Program.Resource> ProcessAsync(string resourceName)
        {
            while(redlock.IsAcquired is false)
            {
                await Task.Delay()
            }
        }
    }
}