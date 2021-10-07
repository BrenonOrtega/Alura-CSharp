using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RedisEventSourcing.Contracts.Handlers;
using RedisEventSourcing.Domain.Entities.Shared;

namespace RedisEventSourcing.Application
{
    public class ConsoleWorker : BackgroundService
    {
        private readonly ILogger<ConsoleWorker> logger;
        private readonly IDataChangedEventHandler<TestObject> handler;

        public ConsoleWorker(ILogger<ConsoleWorker> logger, IDataChangedEventHandler<TestObject> handler)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            handler.DataChanged += (data) => System.Console.WriteLine(data);

            var shouldQuit = false;
            do 
            {
                //var read = await Console.In.ReadLineAsync();
                var read = "hello";
                var message = string.Format("Value read from console {0}", read);
                

                await Task.WhenAll(handler.HandleAsync (this,  new TestObject { Id="123#121#Test", Input = read, CreatedAt = DateTime.Now }),
                Console.Out.WriteLineAsync(message));

                logger.LogInformation(message);

                if("exit".ToLower().Equals(read?.ToLower()))
                    break;

            } while(shouldQuit is false);
        }

        public class TestObject : IEntity<string>
        {
            public string Id { get; set; }
            public string Input { get; internal set; }
            public DateTime CreatedAt { get; internal set; }

            public override string ToString() => $"Id:{Id} - Input: {Input} - Date and time: {CreatedAt}";
        }
    }
}