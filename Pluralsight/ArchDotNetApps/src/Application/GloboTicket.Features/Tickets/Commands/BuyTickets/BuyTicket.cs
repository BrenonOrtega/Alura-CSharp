using GloboTicket.Contracts.Commands.Tickets;
using MediatR;

namespace GloboTicket.Features.Tickets.Commands.BuyTickets
{
    internal class BuyTicket : IRequest, IBuyTicketCommand
    {
        public string BuyerName { get; set; }
        public string BuyerId { get; set; }
        public string EventId { get; set; }
        public decimal Amount { get; set; }
    }
}
