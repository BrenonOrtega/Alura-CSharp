using EntityAccessedData.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityAccessData.DataAccess
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions options) : base(options) { }

        public DbSet<Person> People { get; set; }
        public DbSet<Email> Emails  { get; set; }
        public DbSet<Adress> Addresses { get; set; }

    }
}