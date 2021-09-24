using SimpleMediatrProj.Domain.Message.Commands;
using SimpleMediatrProj.Repositories;
using System;
using System.Threading.Tasks;

namespace SimpleMediatrProj.Domain.Message.Handlers
{
    public class SaveMessageCommandHandler : BaseMessageHandler<SaveMessageCommand, int>
    {
        public SaveMessageCommandHandler(IMessageRepository repo) : base(repo)
        {
        }

        protected override Task<int> HandleRequest(SaveMessageCommand request)
        {
            var message = request.Message;
            message.Id = new Random().Next(1, 10000);
            _repo.Save(message);
            return Task.FromResult(message.Id);
        }
    }
}