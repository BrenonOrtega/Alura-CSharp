using System;

namespace RedisEventSourcing.Domain.Entities.Shared
{
    public interface IAuditableEntity<TKey> : IEntity<TKey>
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}