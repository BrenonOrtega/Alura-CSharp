using System;
using System.IO;
using System.Linq;
using Identity.Data.Extensions;
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
            if (!Database.EnsureCreated())
                EnsureAdminExist();
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
            EnsureAdminExist();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder b)
        {
            var directory = "..\\..\\..";
            var dbPath = directory + "app.db";

            if (!b.IsConfigured)
                b.UseSqlite($"DataSource={ dbPath }");

            base.OnConfiguring(b);
        }
        protected override void OnModelCreating(ModelBuilder b)
        {
            b.ApplyConfiguration(new UserMap());

            base.OnModelCreating(b);
        }

        public void EnsureAdminExist()
        {
            var admin = Users.SingleOrDefault(x => x.Name == "admin" && x.Role == "admin" && x.Id == 1);

            if (admin is null)
            {
                Users.Add(new User
                {
                    Name = "admin",
                    Email = "admin@admin.com",
                    Role = "admin",
                    Password = "admin".GetSha256(),
                    FavoriteMovie = "Godfather"
                });

                SaveChanges();
            }
        }
    }
}