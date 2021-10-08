using System.Threading.Tasks;

namespace RedisEventSourcing.Contracts.Subscribers
{
    public interface IDataChangedEventSubscriber
    {
        Task ListenEventAsync<T>(T data);
    }
}