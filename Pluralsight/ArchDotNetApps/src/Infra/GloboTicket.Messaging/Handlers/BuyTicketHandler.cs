using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GloboTicket.Messaging.Commands;
using MediatR;

namespace GloboTicket.Messaging.Handlers
{
    public class BuyTicketHandler : IRequestHandler<BuyTicketCommand, bool>
    {
        public Task<bool> Handle(BuyTicketCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}