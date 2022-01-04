using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HangfireCron.Shared.Models;

namespace HangfireCron.Shared
{
    public interface IAsyncRepository<T>
    {
        Task<T> GetById(string id);

        Task SaveAsync(T entity);
        Task<IEnumerable<PaybillStatusConsult>> GetAll();
    }
}