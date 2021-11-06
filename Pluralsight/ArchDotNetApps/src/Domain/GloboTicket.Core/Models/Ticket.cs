using System;

namespace GloboTicket.Core.Models
{
    public class Ticket
    {
        public Guid EventId { get; set; }
        public string OwnerId { get; set; }
        public decimal Price { get; set; }
    }
}
