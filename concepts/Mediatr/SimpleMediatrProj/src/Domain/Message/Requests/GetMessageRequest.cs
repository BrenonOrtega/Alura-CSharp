using System;
using System.Collections.Generic;
using MediatR;

namespace SimpleMediatrProj.Domain.Message.Requests
{
    public class GetMessageRequest : IRequest<IEnumerable<Models.Message>>
    {
        public GetMessageRequest(Func<Models.Message, bool> filter = null)
        {
            Filter = filter ?? getAll;
        }

        public Func<Models.Message, bool> Filter { get; set; } 

        private Func<Models.Message, bool> getAll = _ => true;
    }
}