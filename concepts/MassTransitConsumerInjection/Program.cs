using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Threading;

namespace MassTransitConsumerInjection
{
    public class Program
    {
        static Task Main(string[] args)
        {
            var csc = new CancellationTokenSource();

            return Host.CreateDefaultBuilder(args)
                .AddMassTransitServices()
                .Build()
                .RunAsync(csc.Token);
        }
    }
}