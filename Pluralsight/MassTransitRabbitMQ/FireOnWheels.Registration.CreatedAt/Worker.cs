using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using FireOnWheels.Shared.Messaging;
using MassTransit;
using System.Text.Json;
using System.IO;

namespace FireOnWheels.Registration.CreatedAt
{
    public class Worker : IConsumer<ICreatedAt>
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<ICreatedAt> context)
        {
            File.WriteAllText(Path.Join(AppContext.BaseDirectory, "../../CreatedAt.txt"), JsonSerializer.Serialize<ICreatedAt>(context.Message));
            return Task.CompletedTask;
        }
    }
}
