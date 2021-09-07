using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using SimpleMediatrProj.Models;
using SimpleMediatrProj.Repositories;
using SimpleMediatrProj.Requests;
using System.Linq;

namespace SimpleMediatrProj.Handlers.Chats
{
    public class CreateChatCommandHandler : BaseChatHandler<CreateChatCommand, int>
    {
        protected readonly IMessageRepository _messageRepo;
        protected readonly IPersonRepository _personRepo;

        public CreateChatCommandHandler(
            IMessageRepository messageRepo,
            IPersonRepository personRepo,
            IMediator mediator,
            IChatRepository _repo)
            : base(mediator, _repo)
        {
            _messageRepo = messageRepo ?? throw new System.ArgumentNullException(nameof(messageRepo));
            _personRepo = personRepo ?? throw new System.ArgumentNullException(nameof(personRepo));
        }

        protected override Task<int> Handle(CreateChatCommand request)
        {
            var participants = _personRepo.Get(x => x.Id == request.SenderId || x.Id == request.ReceiverId);
            var sender = participants.Single(x => x.Id == request.SenderId);
            var receiver = participants.Single(x => x.Id == request.ReceiverId);

            var newChat = new Chat() { ChatStarter = sender, ChatResponder = receiver };
            newChat.AddMessage(request.InitialMessage);

            _messageRepo.Save(request.InitialMessage);
            _repo.Save(newChat);

            return Task.FromResult((int)newChat.Id);
        }
    }
}