using Identity.Domain.Models;

namespace Identity.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmailAndPassword(string email, string encriptedPassword);
        
        string GetSha256EncryptedPassword(string Password);
    }
}