using System;
using Contracts.Events;

namespace Api.Contract.Events
{
    public class OrderSent : IOrderUsed
    {
        public Guid CorrelationId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; } 
    }
}