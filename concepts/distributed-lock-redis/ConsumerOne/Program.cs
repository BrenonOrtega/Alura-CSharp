using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistributedLock.Commons;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RedLockNet;
using RedLockNet.SERedis;

namespace ConsumerOne
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}
