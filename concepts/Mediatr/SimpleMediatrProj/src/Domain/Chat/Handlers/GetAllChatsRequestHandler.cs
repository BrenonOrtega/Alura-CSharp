using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using SimpleMediatrProj.Domain.Chat.Requests;
using SimpleMediatrProj.Models;
using SimpleMediatrProj.Repositories;

namespace SimpleMediatrProj.Handlers.Chats
{
    public class GetAllChatsRequestHandler : BaseChatHandler<GetAllChatsRequest, IEnumerable<Chat>>
    {
        public GetAllChatsRequestHandler(IMediator mediator, IChatRepository repo) : base(mediator, repo) { }
        protected override Task<IEnumerable<Chat>> HandleRequest(GetAllChatsRequest request)
        {
            return Task.FromResult(_repo.Get(x => true));
        }
    }
}