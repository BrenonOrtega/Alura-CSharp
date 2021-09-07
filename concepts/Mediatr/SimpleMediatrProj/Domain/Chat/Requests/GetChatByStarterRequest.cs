using System.Collections.Generic;
using MediatR;

namespace SimpleMediatrProj.Domain.Chat.Requests
{
    public class GetChatByStarterRequest : IRequest<IEnumerable<Models.Chat>>
    {
        public int StarterId { get; set; }
    }
}