using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace SimpleLock.Processors
{
    public class DatabaseResourceProcessor : IResourceProcessor
    {
        private readonly ILogger<DatabaseResourceProcessor> _logger;
        private readonly IDistributedCache _cache;

        public DatabaseResourceProcessor(ILogger<DatabaseResourceProcessor> logger, IRedisCache cache) =>
            (_cache, _logger) = (cache, logger);

        public async Task<Resource> ProcessAsync(string resourceName)
        {
            try
            {

                var data = await _cache.GetStringAsync(resourceName);
                //var @string = Encoding.UTF8.GetString(data);
                
                return JsonSerializer.Deserialize<Resource>(data);
            
            } catch(Exception e)
            {
                _logger.LogCritical(e.ToString());
                throw;
            }
        }
    }
}