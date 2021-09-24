using System;
using System.Collections.Generic;

namespace SimpleMediatrProj.Models
{
    public class Chat
    {
        public long Id { get; set; }

        public Person ChatStarter { get; set; }

        public Person ChatResponder { get; set; }

        public List<Message> Messages { get; set; } = new List<Message>();

        public void AddMessage(IEnumerable<Message> messages) => Messages.AddRange(messages);

        public void AddMessage(params Message[] messages) => Messages.AddRange(messages);
    }
}