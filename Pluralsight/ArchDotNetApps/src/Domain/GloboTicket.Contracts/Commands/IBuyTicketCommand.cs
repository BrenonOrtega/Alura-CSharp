using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTicket.Contracts.Commands
{
    public interface IBuyTicketCommand
    {
        string BuyerName { get; set; }
        string BuyerId { get; set; }
        string EventId { get; set; }
        decimal Amount { get; set; }
    }
}