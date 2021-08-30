using System;
using Contracts.Events;

namespace Api.Contract.States
{
    public class OrderConsumed : IOrder
    {
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CorrelationId { get; set; }
    }
}