using System;
using Contracts.Events;

namespace Api.Contract.Events
{
    public class Order : IOrderCreated
    {
        public Guid CorrelationId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}