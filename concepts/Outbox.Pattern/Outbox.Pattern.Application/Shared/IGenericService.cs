using System.Threading.Tasks;

namespace Outbox.Pattern.Application.Shared
{
    public interface IGenericProcessor<T>
    {
        Task<Response<T>> ProcessAsync(T value);
    }
}