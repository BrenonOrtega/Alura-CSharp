using SimpleMediatrProj.Models;

namespace SimpleMediatrProj.Repositories
{
    public interface IPersonRepository : IRepository<Person> { }

    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository()
        {
            Models.AddRange(new Person[]
            {
                new() { Id=1, Name="Kyogre" },
                new() { Id=2, Name="Groudon" },
                new() { Id=3, Name="Pikachu" },
                new() { Id=3, Name="Charmander" }
            });
        }
    }
}