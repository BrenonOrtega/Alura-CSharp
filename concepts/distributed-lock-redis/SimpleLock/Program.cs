using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DistributedLock.Commons;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleLock.Configuration;
using StackExchange.Redis;

namespace SimpleLock
{
    class Program
    {
        static async Task Main(string[] args)
        {
            /* var redis = await ConnectionMultiplexer.ConnectAsync("localhost,port:6379");
            var database = redis.GetDatabase();

            while (true)
            {
                using var redlock = await RedLockConfig.GetRedLockAsync();

                if(redlock.IsAcquired)
                {
                    var resourceString = await database.StringGetAsync(RedLockConfig.myLockedResource);
                    var resource = JsonSerializer.Deserialize<Resource>(resourceString);
                    System.Console.WriteLine(resource);

                    resource = resource with { UpdatedAt = DateTime.Now, UpdatedBy = args.FirstOrDefault() };
                    await database.StringSetAsync(RedLockConfig.myLockedResource, JsonSerializer.Serialize(resource));
                    await redlock.DisposeAsync();
                }

                await Task.Delay(300);
            } */

            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.Configure<RedLockConfiguration>(context.Configuration.GetSection(nameof(RedLockConfiguration)));
                });
        }

        internal record Resource(string Name, string Type, DateTime UpdatedAt, string UpdatedBy);
    }
}