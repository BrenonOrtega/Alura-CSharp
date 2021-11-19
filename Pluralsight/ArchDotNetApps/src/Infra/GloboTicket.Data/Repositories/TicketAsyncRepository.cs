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
        public Task<IEnumerable<Ticket>> GetallAsync() => Task.FromResult(_tickets.Select(x => x.Value).AsEnumerable());

        public Task<Ticket> GetByIdAsync<TKey>(TKey id)
        {
            _tickets.TryGetValue(id.ToString(), out var  value);
            return Task.FromResult(value);
        }

        public Task DeleteAsync(Ticket entity) => Task.Run(() => _tickets.Remove(entity.Id));

        public Task SaveAsync(Ticket entity) => Task.FromResult(_tickets.TryAdd(entity.Id, entity));

        public Task UpdateAsync(Ticket entity) => Task.FromResult(_tickets[entity.Id] = entity);
        
        private static IDictionary<string, Ticket> _tickets = new Dictionary<string, Ticket>()
        {
            { "1", new Ticket() { CreatedAt=DateTime.Now, UpdatedAt = DateTime.Now, Id = "1", OwnerId="1000", EventId = Guid.NewGuid() }},
            { "2", new Ticket() { CreatedAt=DateTime.Now, UpdatedAt = DateTime.Now, Id = "2", OwnerId="2000", EventId = Guid.NewGuid() }},
            { "3", new Ticket() { CreatedAt=DateTime.Now, UpdatedAt = DateTime.Now, Id = "3", OwnerId="3000", EventId = Guid.NewGuid() }},
            { "4", new Ticket() { CreatedAt=DateTime.Now, UpdatedAt = DateTime.Now, Id = "4", OwnerId="4000", EventId = Guid.NewGuid() }},
            { "5", new Ticket() { CreatedAt=DateTime.Now, UpdatedAt = DateTime.Now, Id = "5", OwnerId="5000", EventId = Guid.NewGuid() }},
            { "6", new Ticket() { CreatedAt=DateTime.Now, UpdatedAt = DateTime.Now, Id = "6", OwnerId="6000", EventId = Guid.NewGuid() }},
            { "7", new Ticket() { CreatedAt=DateTime.Now, UpdatedAt = DateTime.Now, Id = "7", OwnerId="7000", EventId = Guid.NewGuid() }},
            { "8", new Ticket() { CreatedAt=DateTime.Now, UpdatedAt = DateTime.Now, Id = "8", OwnerId="8000", EventId = Guid.NewGuid() }},
        };
    }
}
