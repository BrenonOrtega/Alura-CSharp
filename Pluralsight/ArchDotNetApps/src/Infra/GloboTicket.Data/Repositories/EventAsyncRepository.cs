using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GloboTicket.Core.Models;
using GloboTicket.Core.Repositories;

namespace GloboTicket.Data.Repositories
{
    public class EventAsyncRepository : IEventAsyncRepository
    {
        public Task<IEnumerable<Event>> GetallAsync() => Task.FromResult(_events.Select(x => x.Value).AsEnumerable());

        public Task<Event> GetByIdAsync<TKey>(TKey id)
        {
            _events.TryGetValue(id.ToString(), out var  value);
            return Task.FromResult(value);
        }

        public Task DeleteAsync(Event entity) => Task.Run(() => _events.Remove(entity.Id));

        public Task SaveAsync(Event entity) => Task.FromResult(_events.TryAdd(entity.Id, entity));

        public Task UpdateAsync(Event entity) => Task.FromResult(_events[entity.Id] = entity);
        
        private static IDictionary<string, Event> _events = new Dictionary<string, Event>()
        {
            { "1", new Event() { CreatedAt=DateTime.Now, UpdatedAt = DateTime.Now, Id = "1", Creator="Metallica", Name = "Metallica Tour" }},
            { "2", new Event() { CreatedAt=DateTime.Now, UpdatedAt = DateTime.Now, Id = "2", Creator="Megadeth", Name = "Megadeth Tour" }},
            { "3", new Event() { CreatedAt=DateTime.Now, UpdatedAt = DateTime.Now, Id = "3", Creator="Pantera", Name = "Pantera Tour" }},
            { "4", new Event() { CreatedAt=DateTime.Now, UpdatedAt = DateTime.Now, Id = "4", Creator="Avenged Sevenfold", Name = "Avenged Sevenfold Tour" }},
            { "5", new Event() { CreatedAt=DateTime.Now, UpdatedAt = DateTime.Now, Id = "5", Creator="Disturbed", Name = "Disturbed Tour" }},
            { "6", new Event() { CreatedAt=DateTime.Now, UpdatedAt = DateTime.Now, Id = "6", Creator="Iron Maiden", Name = "Iron Maiden Tour" }},
            { "7", new Event() { CreatedAt=DateTime.Now, UpdatedAt = DateTime.Now, Id = "7", Creator="Slipknot", Name = "Slipknot Tour" }},
            { "8", new Event() { CreatedAt=DateTime.Now, UpdatedAt = DateTime.Now, Id = "8", Creator="Aaaaaaaaa", Name = "Aaaaaaaaa Tour" }},
        };
    }
}
