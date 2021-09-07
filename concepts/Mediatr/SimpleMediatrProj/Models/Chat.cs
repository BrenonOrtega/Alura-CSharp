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

   

    
}