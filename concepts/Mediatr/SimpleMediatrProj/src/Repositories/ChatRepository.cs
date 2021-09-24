using System.Collections.Generic;
using SimpleMediatrProj.Models;

namespace SimpleMediatrProj.Repositories
{
    public interface IChatRepository : IRepository<Chat>
    {
        IEnumerable<Chat> GetBySender(int senderId);
        IEnumerable<Chat> GetByResponder(int responderId);
    }

    public class ChatRepository : BaseRepository<Chat>, IChatRepository
    {
        public IEnumerable<Chat> GetByResponder(int responderId) => Get(x => x.ChatStarter.Id == responderId);
        public IEnumerable<Chat> GetBySender(int senderId) => Get(x => x.ChatResponder.Id == senderId);
    }

    

    
}