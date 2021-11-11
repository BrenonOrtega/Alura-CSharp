using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GloboTicket.Contracts.Commands;
using MediatR; 

namespace GloboTicket.Messaging.Commands
{
    public class BuyTicketCommand : IBuyTicketCommand, IRequest<bool>
    {
        public string BuyerName { get; set; }
        public string BuyerId { get; set; }
        public string EventId { get; set; }
        public decimal Amount { get; set; }
    }
}