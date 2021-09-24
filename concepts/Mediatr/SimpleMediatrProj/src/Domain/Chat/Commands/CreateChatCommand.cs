using MediatR;

namespace SimpleMediatrProj.Domain.Chat.Commands
{
    public class CreateChatCommand : IRequest<int>
    {
        public CreateChatCommand(int senderId, int receiverId, string text)
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            InitialMessage = new Models.Message() { SenderId = senderId, Text = text };
        }

        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public Models.Message InitialMessage { get; set; }
    }
}