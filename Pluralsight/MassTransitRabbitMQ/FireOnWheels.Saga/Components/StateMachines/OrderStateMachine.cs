using System;
using System.IO;
using System.Text.Json;
using Automatonymous;
using FireOnWheels.Saga.Components.Sagas;
using FireOnWheels.Shared.Messaging;
using Microsoft.Extensions.Logging;

namespace FireOnWheels.Saga.Components.StateMachines
{
    public class OrderStateMachineLogger : ILogger<OrderStateMachine>, IDisposable

    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return this;
        }

        public void Dispose()
        {
            Console.Out.WriteLine("disposed");
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (exception is null)
                File.AppendAllText(Path.Join(AppContext.BaseDirectory, "../../../SagaLog.txt"), state?.ToString());
        }
    }

    public class OrderStateMachine : MassTransitStateMachine<OrderSaga>
    {
        private ILogger<OrderStateMachine> _logger;

        public OrderStateMachine(ILogger<OrderStateMachine> logger) : base()
        {

            _logger = new OrderStateMachineLogger();
            InstanceState(saga => saga.State);

            Event(() => OrderReceived, saga => saga.CorrelateById(c => c.CorrelationId, e => e.Message.Order.Id).SelectId(c => c.Message.Order.Id));
            Event(() => OrderRegistered, saga => saga.CorrelateById(c => c.Message.Order.Id));
            Event(() => OrderNotified, saga => saga.CorrelateById(c => c.Message.Order.Id));


            Initially(
                When(OrderReceived)
                    .Then(Initialize)
                    .Then(c =>
                    {
                        c.Instance.Update(nameof(OrderReceived));
                        File.AppendAllText(Path.Join(AppContext.BaseDirectory, "../../../SagaLog.txt"), "order received /n");
                    })
                    .TransitionTo(WaitingOrderRegistration)
                    .Publish(x => new { x.Data.Id, x.Data.Order })
            );

            During(WaitingOrderRegistration,
                When(OrderRegistered)
                .TransitionTo(WaitingOrderNotification)
                .Then(saga => saga.Instance.Update(nameof(OrderRegistered)))
                .Then(Register)
                .Publish(x => new { x.Data.Order })
            );

            During(WaitingOrderNotification,
                When(OrderNotified)
                .Then(Notify)
                .TransitionTo(OrderFinished)
                .Finalize()
            );

            SetCompletedWhenFinalized();
        }

        public State WaitingOrderCreation { get; private set; }
        public State WaitingOrderRegistration { get; private set; }
        public State WaitingOrderNotification { get; private set; }
        public State OrderFinished { get; private set; }

        public Event<IOrderRegistrationCommand> OrderReceived { get; private set; }
        public Event<IOrderRegisteredEvents> OrderRegistered { get; private set; }
        public Event<IOrderNotifiedEvent> OrderNotified { get; private set; }



        void Initialize(BehaviorContext<OrderSaga, IOrderRegistrationCommand> context)
        {
            File.AppendAllText(Path.Join(AppContext.BaseDirectory, "../../../SagaLog.txt"), JsonSerializer.Serialize(context.Data, new() { WriteIndented = true }));
            _logger.LogInformation("initalizing saga");
            InitializeInstance(context.Instance, context.Data.Order);
        }

        void Register(BehaviorContext<OrderSaga, IOrderRegisteredEvents> context)
        {
            File.AppendAllText(Path.Join(AppContext.BaseDirectory, "../../../SagaLog.txt"), JsonSerializer.Serialize(context.Data, new() { WriteIndented = true }));
            _logger.LogInformation("Registered: {0} ({1})", context.Data.Order.Receiver, context.Instance.Order);
        }

        void Notify(BehaviorContext<OrderSaga, IOrderNotifiedEvent> context)
        {
            File.AppendAllText(Path.Join(AppContext.BaseDirectory, "../../../SagaLog.txt"), JsonSerializer.Serialize(context.Data, new() { WriteIndented = true }));
            _logger.LogInformation("Invalid License: {0} ({1}) - {2}", context.Data.Order.IsFragile, context.Instance.Order,
                context.Data.Order.Sender);
        }


        void InitializeInstance(OrderSaga instance, IOrder data)
        {
            _logger.LogInformation("Initializing: {0} ({1})", data.Receiver, data.Sender);

            instance.Order = data;
        }
    }
}