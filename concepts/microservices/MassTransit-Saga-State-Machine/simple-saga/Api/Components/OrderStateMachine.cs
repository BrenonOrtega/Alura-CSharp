using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Contract.Events;
using Api.Contract.States;
using Automatonymous;
using Contracts;
using Contracts.Events;
using GreenPipes;
using MassTransit;
using CreatedState = Automatonymous.State;
using AppendedState = Automatonymous.State;
using FinishedState = Automatonymous.State;

namespace Api.Components
{
    public class OrderStateMachine : MassTransitStateMachine<OrderState>
    {
        public OrderStateMachine()
        {
            InstanceState(x => x.CurrentState);
            State(() => MessageOrderUsed);
            State(() => MessageOrderConsumed);


            Event(() => OrderCreated, context => context.CorrelateBy(c => c.CorrelationId, order => order.CorrelationId));
            Event(() => OrderFinished, context => context.CorrelateBy(x => x.CorrelationId, order => order.CorrelationId));
            Event(() => OrderUsed, context => context.CorrelateBy(x => x.CorrelationId, order => order.CorrelationId));

            Initially(
                When(OrderCreated)
                    .Then(x =>
                    {
                        x.Instance.CorrelationId = (Guid)x.Data.CorrelationId;
                        x.Instance.StateData = x.Data;
                    })
                    .PublishAsync(context => context.Init<OrderSent>((IOrder)context.Data))
                    .TransitionTo(MessageOrderUsed));
        }

        public CreatedState MessageOrderCreated { get; set; }
        public AppendedState MessageOrderUsed { get; set; }
        public FinishedState MessageOrderConsumed { get; set; }

        public Event<IOrderUsed> OrderUsed { get; set; }
        public Event<IOrderFinished> OrderFinished { get; set; }
        public Event<IOrderCreated> OrderCreated { get; set; }
    }
}