using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using RedisEventSourcing.Contracts.Handlers;
using RedisEventSourcing.Domain.Entities.Shared;

namespace RedisEventSourcing.Events.Handlers
{
    public class DataChangedEventHandler<T> : IDataChangedEventHandler<T> where T : IEntity<string>
    {
        private readonly IDistributedCache cache;

        public DataChangedEventHandler(IDistributedCache cache)
        {
            this.cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }
        public event Action<T> DataChanged;

        public Task HandleAsync(object sender, T data)
        {
            DataChanged(data);

            return cache.SetAsync(data.Id, 
                Encoding.UTF8.GetBytes(JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true })),
                new DistributedCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(3) }
            );
        }
    }
}