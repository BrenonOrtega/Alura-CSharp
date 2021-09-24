using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SimpleMediatrProj.Domain.Chat.Requests;
using SimpleMediatrProj.Domain.Message.Requests;
using SimpleMediatrProj.Models;
using SimpleMediatrProj.Repositories;

namespace SimpleMediatrProj.Handlers.Chats
{
     public class GetChatRequestHandler : BaseChatHandler<GetChatRequest, Chat>
    {
        public GetChatRequestHandler(IMediator mediator, IChatRepository _repo) : base(mediator, _repo) { }

        protected override async Task<Chat> HandleRequest(GetChatRequest request)
        {
            var chat = _repo.Get(x => x.Id == request.ChatId).SingleOrDefault();
            var messages = await _mediator.Send(new GetMessageRequest(x => x.ChatId == chat.Id));
            chat.AddMessage(messages);
            return chat;
        }
    }
}