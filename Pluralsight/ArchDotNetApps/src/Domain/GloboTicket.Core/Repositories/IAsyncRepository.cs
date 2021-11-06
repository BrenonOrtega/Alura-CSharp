using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GloboTicket.Core.Repositories
{
    public interface IAsyncRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetallAsync();
        Task<TEntity> GetByIdAsync<TKey>(TKey id);
        Task SaveAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
