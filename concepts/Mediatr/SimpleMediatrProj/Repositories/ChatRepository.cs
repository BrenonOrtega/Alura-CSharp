using System.Collections.Generic;
using SimpleMediatrProj.Models;

namespace SimpleMediatrProj.Repositories
{
    public class ChatRepository : BaseRepository<Chat>
    {
        protected override List<Chat> Models { get; } = new List<Chat>()
        {
            new() {Id=1, ChatStarter = new() { Id=1, Name="Kyogre" }, ChatResponder = new(){ Id=2, Name="Groudon" } },
            new() {Id=2, ChatStarter = new() { Id=3, Name="Pikachu" }, ChatResponder = new(){ Id=3, Name="Charmander" } },
        };
    }
}