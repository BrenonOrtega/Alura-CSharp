using MediatR;
using System.Collections.Generic;

namespace SimpleMediatrProj.Domain.Chat.Requests
{
    public class GetChatByReceiverRequest : IRequest<IEnumerable<Models.Chat>>
    {
        public int ReceiverId { get; set; }
    }
}