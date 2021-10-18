using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArchAspNetDynamoDb.Domain.Models.Entities;

namespace ArchAspNetDynamoDb.Domain.Repositories
{
    public interface IRepository<TEntity> 
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> FindByHashKey<TPartitionKey, TSortKey>(TPartitionKey partitionkey, TSortKey sortKey);
        Task SaveAsync(TEntity paymentRefund);
    }
}