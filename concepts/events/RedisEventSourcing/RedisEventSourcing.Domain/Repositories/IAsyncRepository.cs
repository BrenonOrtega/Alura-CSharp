using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedisEventSourcing.Domain.Repositories
{
    public interface IAsyncRepository<T>
    {
        Task AddAsync(T entity);
        Task<IEnumerable<T>> GetAsync(Func<T, bool> filter);
        Task<T> GetOneAsync(Func<T, bool> filter);
    }
}