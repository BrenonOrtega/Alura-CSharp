using System;
using System.Collections.Generic;
using System.Reflection;

namespace MessageContract
{
    public class OrderMessage
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Text { get; set; }
        public string MessagePath { get; set; } = Assembly.GetExecutingAssembly().GetName().ToString();
        public string Sender { get; set; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

        public void UpdateDate() => 
            UpdatedAt = DateTime.UtcNow; 
    }
}