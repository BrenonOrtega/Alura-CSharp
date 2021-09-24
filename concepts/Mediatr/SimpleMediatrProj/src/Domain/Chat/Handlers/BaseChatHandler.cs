using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleMediatrProj.Repositories;

namespace SimpleMediatrProj.Handlers.Chats
{
    public abstract class BaseChatHandler<TRequest, TOutput> : IRequestHandler<TRequest, TOutput> 
        where TRequest : IRequest<TOutput>
    {
        protected abstract Task<TOutput> HandleRequest(TRequest request);
        protected readonly IMediator _mediator;
        protected readonly IChatRepository _repo;

        public BaseChatHandler(IMediator mediator, IChatRepository _repo)
        {
            this._mediator = mediator ?? throw new System.ArgumentNullException(nameof(_mediator));
            this._repo = _repo ?? throw new System.ArgumentNullException(nameof(_repo));
        }

        public Task<TOutput> Handle(TRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return HandleRequest(request);
        }

    }
}
