using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using static SimpleLock.Program;

namespace SimpleLock.Processors
{
    internal class DatabaseResourceProcessor : IResourceProcessor
    {
        private readonly ILogger<DatabaseResourceProcessor> _logger;
        private readonly IDistributedCache _cache;

        public DatabaseResourceProcessor(ILogger<DatabaseResourceProcessor> logger, IDistributedCache cache) =>(_cache, _logger) = (cache, logger);

        public async Task<Resource> ProcessAsync(string resourceName)
        {
            var data = await _cache.GetStringAsync(resourceName);
            return JsonSerializer.Deserialize<Resource>(data);
        }
    }
}