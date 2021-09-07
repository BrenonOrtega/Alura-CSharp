using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SimpleMediatrProj.Models;
using SimpleMediatrProj.Repositories;
using SimpleMediatrProj.Requests;

namespace SimpleMediatrProj.Handlers.Chats
{
     public class GetChatRequestHandler : BaseChatHandler<GetChatRequest, Chat>
    {
        public GetChatRequestHandler(IMediator mediator, IChatRepository _repo) : base(mediator, _repo) { }

        protected override Task<Chat> Handle(GetChatRequest request)
        {
            var chat = _repo.Get(x => x.Id == request.ChatId).SingleOrDefault();
            return Task.FromResult(chat);
        }
    }
}