using GloboTicket.Contracts.Commands;
using GloboTicket.Features.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.Features.Tickets.Commands.BuyTicket
{
    public interface IBuyTicketCommandHandler
    {
        Task HandleAsync(IBuyTicketCommand command, CancellationToken token = default);
    }
}
