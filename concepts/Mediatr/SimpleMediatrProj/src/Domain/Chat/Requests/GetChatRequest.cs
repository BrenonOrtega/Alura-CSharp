using MediatR;

namespace SimpleMediatrProj.Domain.Chat.Requests
{
    public class GetChatRequest : IRequest<Models.Chat>
    {
        public int ChatId { get; set; }

        public GetChatRequest(int id)
        {
            ChatId = id;
        }
    }
}
