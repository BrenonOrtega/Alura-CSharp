using System;

namespace MassTransit.Contracts
{
    public class MessageCreateDto
    {
        public string Text { get; set; }

        public Message ToModel() => new Message() { Text = this.Text, };
    }
}