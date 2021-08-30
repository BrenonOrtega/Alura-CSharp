using System;
using System.IO;
using MessageContract;
using Microsoft.EntityFrameworkCore;

namespace infra
{
    public class ChatContext : DbContext
    {
        protected ChatContext() : base() { }

        public ChatContext(DbContextOptions opts) : base(opts) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlite(Path.Join(AppContext.BaseDirectory, "..\\..\\app.db"));
            }

            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new OrderMessageMap());
            base.OnModelCreating(builder);
        }

        public DbSet<OrderMessage> Messages { get; set; }
    }
}
