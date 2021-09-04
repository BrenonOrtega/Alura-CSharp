using Automatonymous;
using FireOnWheels.Shared.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace FireOnWheels.Saga.Components.Sagas
{
    public class OrderSaga : SagaStateMachineInstance
    {
        private Guid correlationId;

        public Guid CorrelationId
        {
            get => correlationId;
            set => correlationId = value;
        }

        public State State { get; set; }

        public Guid OrderId { get; set; }

        public IOrder Order { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<string> Updates { get; set; } = new HashSet<string>();

        public void Update(string eventName) =>
            Updates.Add($"Update Hour: { DateTime.Now } - ID: { Order.Id } - CorrelationId: { CorrelationId } Updater: { eventName } ");

        public Task WriteUpdates() => File.WriteAllTextAsync(AssemblyPath, SerialializeUpdates);
        private string SerialializeUpdates =>
             JsonSerializer.Serialize<ICollection<string>>(Updates, new JsonSerializerOptions { WriteIndented = true });

        private string AssemblyPath => Path.Join(AppContext.BaseDirectory, "..\\..\\..\\SagaUpdates.txt");
    }
}