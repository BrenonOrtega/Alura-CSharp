using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using RedLockNet;

namespace SimpleLock.Extensions
{
    public static class PoliciesExtensions
    {
        public static async Task<IDistributedLockFactory> UsePolicy(this IDistributedLockFactory factory)
        {
            var policy = Policy<IRedLock>.HandleResult(redlock => redlock.IsAcquired is false)
                .WaitAndRetryAsync(5, x => TimeSpan.FromMilliseconds(Math.Pow(x, 2)));

            var result = await policy.ExecuteAndCaptureAsync(() => factory.CreateLockAsync("a", TimeSpan.Zero));
            return result;
        }
    }
}