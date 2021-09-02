using System;
using System.Collections.Generic;
using System.IO;
using Automatonymous;
using FireOnWheels.Shared.Messaging;

namespace FireOnWheels.Saga.Components.Sagas
{
    public class OrderSaga : SagaStateMachineInstance
    {
        private Guid correlationId;

        public Guid CorrelationId 
        { 
            get 
            { 
                PropertyChanged(); 
                return correlationId; 
            } 
            set { correlationId = value; } 
        }

        private void PropertyChanged()
        {
            File.AppendAllText(Path.Join(AppContext.BaseDirectory, "../../../saga"), $"Just been used {correlationId} ");
        }

        public State State { get; set; }

        public Guid OrderId { get; set; }

        public IOrder Order { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<string> Updates { get; set; } = new HashSet<string>();

        public void Update(string eventName) => Updates.Add($"Update Hour: {DateTime.Now} - Updater: { eventName } ");



    }
}