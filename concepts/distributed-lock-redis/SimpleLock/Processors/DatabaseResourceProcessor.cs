using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace SimpleLock.Processors
{
    public class DatabaseResourceProcessor : IResourceProcessor
    {
        private readonly ILogger<DatabaseResourceProcessor> _logger;
        private readonly IDatabase _cache;

        public DatabaseResourceProcessor(ILogger<DatabaseResourceProcessor> logger, IDatabase cache) =>
            (_cache, _logger) = (cache, logger);

        public async Task<Resource> ProcessAsync(string resourceName)
        {
            try
            {

                var data = await _cache.StringGetAsync(resourceName);
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