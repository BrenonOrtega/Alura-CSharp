using System;
using Automatonymous;
using Contracts.Events;
using MassTransit;

namespace Api.Components
{
    public class OrderState : SagaStateMachineInstance, CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; set; }
        public State CurrentState { get; set; }
        public IOrder StateData { get;set; }
 
    }
}