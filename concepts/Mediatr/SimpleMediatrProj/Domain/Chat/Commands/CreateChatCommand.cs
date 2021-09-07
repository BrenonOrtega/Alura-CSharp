using MediatR;
using SimpleMediatrProj.Models;

namespace SimpleMediatrProj.Domain.Chat.Commands
{
    public class CreateChatCommand : IRequest<int>
    {
        public CreateChatCommand(int senderId, int receiverId, string text)
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            InitialMessage = new Message() { SenderId = senderId, Text = text };
        }

        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public Message InitialMessage { get; set; }
    }
}