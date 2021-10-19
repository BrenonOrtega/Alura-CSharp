using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArchAspNetDynamoDb.Domain.Repositories
{
    public interface IRepository<TEntity> 
    {
        Task<IEnumerable<TEntity>> GetAllAsync(string key);

        Task <IEnumerable<TEntity>> GetByDateAsync(DateTime date);

        Task SaveAsync(TEntity entity);
    }
}