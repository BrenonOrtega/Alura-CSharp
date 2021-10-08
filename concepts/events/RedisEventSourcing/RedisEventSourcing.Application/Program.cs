using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RedisEventSourcing.Contracts.Handlers;
using RedisEventSourcing.Events;
using RedisEventSourcing.Events.Handlers;
using RedisEventSourcing.Infra.Extensions;
using static RedisEventSourcing.Application.ConsoleWorker;

namespace RedisEventSourcing.Application
{
    public class Program
    {
        static void Main(string[] args) =>
            CreateHost(args).Build().Run();

        static IHostBuilder CreateHost(string[] args) =>
            new HostBuilder().ConfigureHostConfiguration(cfg =>
            {
                cfg.AddJsonFile("appsettings.Json", false, true);
                cfg.AddEnvironmentVariables();
                cfg.AddCommandLine(args);
            }).ConfigureServices((ctx, services) =>
            {
                services.AddRedisCaching(ctx.Configuration);
                services.AddSingleton(typeof(IDataChangedEventHandler<>), typeof(DataChangedEventHandler<>));
                services.AddSingleton<FileWriterSubscriber>();
                services.AddHostedService<ConsoleWorker>();
                services.AddSubscribers<TestObject>();
            });
    }
}
