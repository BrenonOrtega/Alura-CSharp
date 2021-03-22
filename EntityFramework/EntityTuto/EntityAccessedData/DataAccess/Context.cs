using EntityAccessedData.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityAccessData.DataAccess
{
    public class PeopleContext : DbContext
    {
         public DbSet<Person> People { get; set; }
        public DbSet<Email> Emails  { get; set; }
        public DbSet<Adress> Addresses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlite("Data Source = ../Database/Data.db");
        }

    }
}