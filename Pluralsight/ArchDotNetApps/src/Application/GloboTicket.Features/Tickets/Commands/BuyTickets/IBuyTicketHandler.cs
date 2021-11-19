using GloboTicket.Contracts.Commands.Tickets;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.Features.Tickets.Commands.BuyTickets
{
    public interface IBuyTicketHandler
    {
        Task HandleAsync(IBuyTicketCommand command, CancellationToken token = default);
    }
}
