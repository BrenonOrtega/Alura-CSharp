using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Identity.Data.Extensions;
using Identity.Domain.Models;
using Identity.Domain.Repositories;
using static Identity.Domain.Models.User;

namespace Identity.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            if (!Exists(id))
                throw new System.Exception("User does Not Exists");

            _context.Users.Remove(GetById(id));
            _context.SaveChanges();
        }

        public virtual IQueryable<User> Get(Expression<System.Func<User, bool>> filter = null)
        {
            filter ??= x => true;
            var query = _context.Users.Where(filter);

            return query;
        }

        public Task<User> GetByEmailAndPassword(string email, string password)
        {
            var user = Get(x => x.Email == email && x.Password == password)
                .SingleOrDefault();

            return Task.FromResult(user ?? Null);
        }

        public User GetById(int id)
        {
            var user = Get(u => u.Id == id)
                .DefaultIfEmpty(User.Null)
                .SingleOrDefault();

            return user;
        }
        public void Save(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Update<TData>(int id, TData updatedData)
        {
            var user = GetById(id);

            if (user == Null)
                throw new System.Exception("Not found");

            _context.Entry(user).CurrentValues.SetValues(updatedData);
        }

        bool Exists(int id) => _context.Users.Any(user => user.Id == id);
    }
}