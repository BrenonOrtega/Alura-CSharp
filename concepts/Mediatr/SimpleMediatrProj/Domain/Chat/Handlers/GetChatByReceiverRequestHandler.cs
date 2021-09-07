using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using SimpleMediatrProj.Models;
using SimpleMediatrProj.Repositories;
using SimpleMediatrProj.Requests;

namespace SimpleMediatrProj.Handlers.Chats
{
    public class GetChatByReceiverRequestHandler : BaseChatHandler<GetChatByReceiverRequest, IEnumerable<Chat>>
    {
        public GetChatByReceiverRequestHandler(IMediator mediator, IChatRepository repo) : base(mediator, repo) { }
        protected override Task<IEnumerable<Chat>> Handle(GetChatByReceiverRequest request)
        {
            var chats = _repo.GetByResponder(request.ReceiverId);
            return Task.FromResult(chats);
        }
    }
}