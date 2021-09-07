using System.Collections.Generic;
using MediatR;

namespace SimpleMediatrProj.Domain.Chat.Requests
{
    public class GetAllChatsRequest : IRequest<IEnumerable<Models.Chat>>
    {
        public int PagingSize { get; set; }
        public int Offset { get; set; }
    }
}