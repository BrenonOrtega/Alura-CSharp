using System;
using System.Collections.Generic;

namespace MassTransit.Contracts
{
    public class Message
    {
        public Guid CorrelationId { get; set; } = Guid.NewGuid();

        public string State { get; set; } = "Created";

        public string Text { get; set; }

        public string WeatherConditions { get; set; }

        public IList<string> MessagePaths { get; set; } = new List<string>();

        public Message()
        {
            MessagePaths.Add(AppDomain.CurrentDomain.FriendlyName);
        }
    }
}
