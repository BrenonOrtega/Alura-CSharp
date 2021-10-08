using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using RedisEventSourcing.Contracts.Handlers;
using RedisEventSourcing.Contracts.Subscribers;
using RedisEventSourcing.Domain.Entities.Shared;

namespace RedisEventSourcing.Events
{
    public class FileWriterSubscriber : IDataChangedEventSubscriber 
    {
        public Task ListenEventAsync<T>(T data) => WriteToFile(data);
        public Task WriteToFile<T>(T data) => File.WriteAllTextAsync(Path.Join(AppContext.BaseDirectory, "..\\..\\..\\event-file.json"),
            JsonSerializer.Serialize(new { CreatedAt = DateTime.Now, Data = data }, new JsonSerializerOptions() { WriteIndented = true }));

    }
}