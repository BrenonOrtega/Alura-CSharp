using System;
using System.Linq;
using Xunit;
using Identity.Data;
using Identity.Data.Repositories;
using Identity.Data.Extensions;

namespace Identity.Tests
{
    public class RepositoryTests
    {
        [Fact]
        public void Repository_Instantiation_Should_Add_Admin()
        {
            var ctx = new AppDbContext();
            var repo = new UserRepository(ctx); 
            var admin = repo.Get().FirstOrDefault();

            Assert.NotNull(admin);
        }

        [Fact]
        public void Query_First_User_Should_Retrieve_Admin()
        {
            var ctx = new AppDbContext();
            var repo = new UserRepository(ctx);

            var expectedEmail = "admin.role@admin.com";
            var expectedPassword = "admin".GetSha256();

            var admin = repo.Get().FirstOrDefault();

            Assert.Equal(expectedEmail, admin.Email);
            Assert.Equal(expectedPassword, admin.Password);
        }
    }
}
