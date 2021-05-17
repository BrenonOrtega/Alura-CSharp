using CatalogApp.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace CatalogApp.Database
{
    public class ReadingAppContext : DbContext
    {
        public DbSet<Book> Books {get; set;} 
        public DbSet<ReadingList> ReadingLists { get; set; }
        public ReadingAppContext(DbContextOptions<ReadingAppContext> options) : base(options)
        {
        }
    }   
}