using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DistributedLock.Commons;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleLock.Configuration;
using SimpleLock.Processors;
using Multiplexer = StackExchange.Redis.ConnectionMultiplexer;
namespace SimpleLock
{
    class Program
    {
        static Task Main(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddScoped<IResourceProcessor, DatabaseResourceProcessor>();
                    services.Decorate<IResourceProcessor, RedLockResourceProcessor>();

                    services.AddHostedService<ResourceWorker>();
                })
                .Build()
                .RunAsync();
        }
    }
}