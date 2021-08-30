using System;
using MassTransit;

namespace Contracts.Events
{
    public interface IOrder : CorrelatedBy<Guid>
    {
        string Message { get; set; }
        DateTime CreatedAt { get; set; }
    }
}