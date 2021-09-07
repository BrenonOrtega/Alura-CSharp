using System;
using System.Collections.Generic;

namespace SimpleMediatrProj.Models
{
    public class Chat
    {
        public long Id { get; set; }

        public Person ChatStarter { get; set; }

        public Person ChatResponder { get; set; }

        public ICollection<Message> Messages { get; set; } = new HashSet<Message>();

        public void AddMessage(Message message) => 
            Messages.Add(
                (message.SenderId == ChatStarter.Id || message.Id == ChatResponder.Id )
                ? message 
                : throw new ArgumentException()
            );
    }

    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string Text { get; set; }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}