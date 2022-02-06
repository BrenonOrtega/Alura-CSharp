using System;
using System.Threading.Tasks;

namespace Outbox.Pattern.Application.Shared
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync<V>(V id) where V: IEquatable<V>, IComparable<V>;
        Task<Response> SaveAsync(T model);
    }
}
