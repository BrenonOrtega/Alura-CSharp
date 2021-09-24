using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleMediatrProj.Repositories;

namespace SimpleMediatrProj.Domain.Message.Handlers
{
    public abstract class BaseMessageHandler<TRequest, TOutput> : IRequestHandler<TRequest, TOutput> 
        where TRequest: IRequest<TOutput>
    {
        protected readonly IMessageRepository _repo;

        public BaseMessageHandler(IMessageRepository repo)
        {
            _repo = repo;
        }
        
        protected abstract Task<TOutput> HandleRequest(TRequest request);
        public Task<TOutput> Handle(TRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return HandleRequest(request);
        }
    }
}