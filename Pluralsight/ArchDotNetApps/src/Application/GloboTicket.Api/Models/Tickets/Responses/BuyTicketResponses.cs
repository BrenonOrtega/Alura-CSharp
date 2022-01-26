using System;

namespace GloboTicket.Api.Models.Tickets.Responses
{
    public class BuyTicketResponse
    {
        public string Guid { get; set; }

        DateTime BuyDate { get; set; }
        
        public TicketEventResponse Event { get; set; }
    }
}