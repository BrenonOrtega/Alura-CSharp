using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Identity.Data.Extensions;
using Identity.Domain.Models;
using Identity.Domain.Repositories;
using System.Threading.Tasks;

namespace Identity.Data.Repositories
{
    public class DummyUserRepository : IUserRepository
    {
        private static IEnumerable<User> Users = new HashSet<User>
        {
            new User() { Id = 1, Email="First.Dummy@test.com", Name="DummyAdmin", Password="dummy-admin".GetSha256(), FavoriteMovie="dummy movie", Role="admin" },
            new User() { Id = 2, Email="Second.Dummy@test.com", Name="DummyUser", Password="dummy-user".GetSha256(), FavoriteMovie="dummy movie", Role="user" },
        };

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public System.Linq.IQueryable<User> Get(Expression<Func<User, bool>> filter) 
        {
            var compiledFilter = filter.Compile();
            var query = Users.Where(compiledFilter)
               ;

            return query.AsQueryable();
        }

        public Task<User> GetByEmailAndPassword(string email, string password) => Task.FromResult(
            Get(x => x.Email.ToLower() == email.ToLower() && x.Password.ToLower() == password.GetSha256().ToLower())
            .SingleOrDefault());

        public User GetById(int id) => 
            Get(x => x.Id == id).SingleOrDefault();

        public string GetSha256EncryptedPassword(string Password)
        {
            throw new NotImplementedException();
        }

        public void Save(User entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update<TData>(int id, TData updatedData)
        {
            throw new System.NotImplementedException();
        }
    }
}