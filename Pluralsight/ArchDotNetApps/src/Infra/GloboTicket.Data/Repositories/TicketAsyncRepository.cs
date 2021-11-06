using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GloboTicket.Core.Models;
using GloboTicket.Core.Repositories;

namespace GloboTicket.Data.Repositories
{
    public class TicketAsyncRepository : ITicketAsyncRepository
    {
        public Task DeleteAsync(Event entity) => throw new NotImplementedException();

        public Task<IEnumerable<Event>> GetallAsync() => Task.FromResult(_events.Select(x => x.Value).AsEnumerable());


        public Task<Event> GetByIdAsync<TKey>(TKey id)
        {
            _events.TryGetValue(id.ToString(), out var  value);
            return Task.FromResult(value);
        }

        public Task SaveAsync(Event entity) => Task.FromResult(_events.TryAdd(entity.Id, entity));

        public Task UpdateAsync(Event entity) => Task.FromResult(_events[entity.Id] = entity);
        private static IDictionary<string, Event> _events = new Dictionary<string, Event>()
        {
            { "1", new Event() { CreatedAt=DateTime.Now, UpdatedAt = DateTime.Now, Id = "1", Creator="Metallica", Name = "Thrash Garage Tour Sp" }},
            { "2", new Event() { CreatedAt=DateTime.Now, UpdatedAt = DateTime.Now, Id = "2", Creator="Metallica", Name = "Thrash Garage Tour Sp" }},
            { "3", new Event() { CreatedAt=DateTime.Now, UpdatedAt = DateTime.Now, Id = "3", Creator="Metallica", Name = "Thrash Garage Tour Sp" }},
            { "4", new Event() { CreatedAt=DateTime.Now, UpdatedAt = DateTime.Now, Id = "4", Creator="Metallica", Name = "Thrash Garage Tour Sp" }},
            { "5", new Event() { CreatedAt=DateTime.Now, UpdatedAt = DateTime.Now, Id = "5", Creator="Metallica", Name = "Thrash Garage Tour Sp" }},
            { "6", new Event() { CreatedAt=DateTime.Now, UpdatedAt = DateTime.Now, Id = "6", Creator="Metallica", Name = "Thrash Garage Tour Sp" }},
            { "7", new Event() { CreatedAt=DateTime.Now, UpdatedAt = DateTime.Now, Id = "7", Creator="Metallica", Name = "Thrash Garage Tour Sp" }},
            { "8", new Event() { CreatedAt=DateTime.Now, UpdatedAt = DateTime.Now, Id = "8", Creator="Metallica", Name = "Thrash Garage Tour Sp" }},
        };
    }
}
