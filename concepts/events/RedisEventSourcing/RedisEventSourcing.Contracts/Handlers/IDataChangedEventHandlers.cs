using System;
using System.Threading.Tasks;

namespace RedisEventSourcing.Contracts.Handlers
{
    public interface IDataChangedEventHandler<T> 
    {
        event Func<T, Task> DataChanged;
        Task HandleAsync(object sender, T data);
        
    }
}