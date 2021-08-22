using System.Threading.Tasks;
using Identity.Domain.Models;

namespace Identity.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAndPassword(string email, string password);
    }
}