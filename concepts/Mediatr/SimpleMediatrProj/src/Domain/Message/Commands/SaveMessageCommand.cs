using MediatR;

namespace SimpleMediatrProj.Domain.Message.Commands
{
    public class SaveMessageCommand : IRequest<int>
    {
        public Models.Message Message { get; set; } 
    }
}