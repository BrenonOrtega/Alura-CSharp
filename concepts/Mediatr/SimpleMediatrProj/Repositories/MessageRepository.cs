using SimpleMediatrProj.Models;

namespace SimpleMediatrProj.Repositories
{
    public interface IMessageRepository : IRepository<Message> { }
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository()
        {
            Models.AddRange(new Message[]
            {
                new() { Id = 1, SenderId = 1, Text = "Hello there my friend" },
                new() { Id = 2, SenderId = 2, Text = "Hey dude" },
                new() { Id = 3, SenderId = 1, Text = "How're you?" },
                new() { Id = 4, SenderId = 2, Text = "good, good" },
                new() { Id = 5, SenderId = 1, Text = "that's nice" },
                new() { Id = 6, SenderId = 2, Text = "does it not?" },
                new() { Id = 7, SenderId = 3, Text = "Hello there my friend" },
                new() { Id = 8, SenderId = 4, Text = "Hello there my friend" },
                new() { Id = 9, SenderId = 3, Text = "how have you been:?" },
                new() { Id = 10, SenderId = 4, Text = "so so, life's hard" },
                new() { Id = 11, SenderId = 3, Text = "Yeah I know" },
                new() { Id = 12, SenderId = 4, Text = "wow" },
            });
        }
    }
}