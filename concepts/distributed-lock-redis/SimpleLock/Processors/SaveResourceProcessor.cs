using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace SimpleLock.Processors
{
    public class SaveResourceProcessor : IResourceProcessor
    {
        private readonly ILogger<SaveResourceProcessor> logger;
        private readonly IDistributedCache cache;
        private readonly IResourceProcessor next;

        public SaveResourceProcessor(ILogger<SaveResourceProcessor> logger, IDistributedCache cache, IResourceProcessor next)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.cache = cache ?? throw new ArgumentNullException(nameof(cache));
            this.next = next ?? throw new ArgumentNullException(nameof(next));
        }
        public async Task<Resource> ProcessAsync(string resourceName)
        {
            var resource = new Resource("This is a created \"Resource\".", "\"Resource\"", DateTime.Now, "Hand");
            await cache.SetStringAsync(resourceName, JsonSerializer.Serialize(resourceName));

            return await next.ProcessAsync(resourceName);
        }
    }
}