using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleMediatrProj.Domain.Message.Requests;
using SimpleMediatrProj.Repositories;

namespace SimpleMediatrProj.Domain.Message.Handlers
{
    public class GetMessageRequestHandler : BaseMessageHandler<GetMessageRequest, IEnumerable<Models.Message>>
    {
        public GetMessageRequestHandler(IMessageRepository repo) : base(repo) {  }

        protected override Task<IEnumerable<Models.Message>> HandleRequest(GetMessageRequest request)
        {
            return Task.FromResult(_repo.Get(request.Filter).AsEnumerable());
        }
    }
}