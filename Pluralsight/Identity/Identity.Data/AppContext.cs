using System;
using System.IO;
using Identity.Data.Maps;
using Identity.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Identity.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext() : base()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder b)
        {
            var directory = Path.Join(System.AppContext.BaseDirectory, "..\\..\\..\\Database");
            var dbPath = Path.Join(directory, "app.db");

            if (!b.IsConfigured)
            {
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                b.UseSqlite($"DataSource={ dbPath }");
            }

            base.OnConfiguring(b);
        }
        protected override void OnModelCreating(ModelBuilder b)
        {
            b.ApplyConfiguration(new UserMap());

            base.OnModelCreating(b);
        }
    }
}