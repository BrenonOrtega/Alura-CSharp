using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using RedisEventSourcing.Contracts.Handlers;
using RedisEventSourcing.Domain.Entities.Shared;

namespace RedisEventSourcing.Events.Handlers
{
    public class DataChangedEventHandler<T> : IDataChangedEventHandler<T> where T : IEntity<string>
    {
        public delegate Task PersistedData(T data);

        private readonly IDistributedCache cache;

        public DataChangedEventHandler(IDistributedCache cache)
        {
            this.cache = cache ?? throw new ArgumentNullException();
        }

        public event Func<T, Task> DataChanged;

        public async Task HandleAsync(object sender, T data)
        {
            await DataChanged(data);
                
            var serializedData = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            await cache.SetStringAsync(data.Id, serializedData);
        }
    }
}