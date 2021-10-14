using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArchAspNetDynamoDb.Api.Repositories
{
    public interface IRepository<TEntity> 
    {
        IAsyncEnumerable<TEntity> GetAll();
        Task<TEntity> FindByHashKey<TKey>(TKey key) where TKey: notnull, ;        
    }
}