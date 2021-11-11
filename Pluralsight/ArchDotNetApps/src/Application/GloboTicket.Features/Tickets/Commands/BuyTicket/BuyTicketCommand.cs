using GloboTicket.Contracts.Commands;
using MediatR;

namespace GloboTicket.Features.Commands
{
    public class BuyTicketCommand : IRequest, IBuyTicketCommand
    {
        public string BuyerName { get; set; }
        public string BuyerId { get; set; }
        public string EventId { get; set; }
        public decimal Amount { get; set; }
    }
}
