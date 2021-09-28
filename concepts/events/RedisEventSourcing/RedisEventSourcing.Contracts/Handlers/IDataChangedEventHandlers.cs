using System;
using System.Threading.Tasks;

namespace RedisEventSourcing.Contracts.Handlers
{
    public interface IDataChangedEventHandler<T>
    {
        delegate string Serialize(T data);
        event Action<T> DataChanged;
        Task HandleAsync(object sender, T data);
        
    }
}