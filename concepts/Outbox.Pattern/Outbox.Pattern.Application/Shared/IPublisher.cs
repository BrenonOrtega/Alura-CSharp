using System;
using System.Threading.Tasks;

namespace Outbox.Pattern.Application.Shared
{
    public interface IPublisher<T> : IGenericProcessor<T>
    {
    }
}