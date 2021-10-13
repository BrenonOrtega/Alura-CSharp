using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon;
using Amazon.Extensions.NETCore.Setup;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ExampleApplication
{
    class Program
    {
        static IHost AppHost;
        static void Main(string[] args)
        {
            AppHost = Host.CreateDefaultBuilder(args)
                .ConfigureServices((ctx,x) => 
                {
                    var config = ctx.Configuration;
                    x.AddAWSService<IAmazonDynamoDB>();
                    x.AddScoped<IDynamoDBContext, DynamoDBContext>();
                })
                .Build();
        }

        public class App
        {
            private readonly ILogger<App> _logger;
            private readonly IDynamoDBContext _dynamo;

            public App(IDynamoDBContext dynamo, ILogger<App> logger) =>
                (_dynamo, _logger) = (dynamo, logger);

            public async Task Run()
            {
                bool exit = default;
                do
                {
                    _logger.LogInformation("Create or retrieve all tables:");
                    if() 
                }
            }

            public async Task CreateTable(string tableName)
            {
                _dynamo.L
            }
        }
    }
}
