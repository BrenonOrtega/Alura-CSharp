using Microsoft.EntityFrameworkCore.Design;
using Identity.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Identity.Data.Extensions;

namespace Identity.Data.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> b)
        {
            b.ToTable(nameof(User))
                .HasKey(p => p.Id);

            b.Property(p => p.Id).HasColumnType<int>("INTEGER");
            b.Property(p => p.Name).HasColumnType<string>("varchar(30)").IsRequired();
            b.Property(p => p.Email).HasColumnType<string>("varchar(120)").IsRequired();
            b.Property(p => p.Password).HasColumnType<string>("varchar(200)").IsRequired();
            b.Property(p => p.FavoriteMovie).HasColumnType<string>("varchar(35)").IsRequired();
            b.Property(p => p.Role).HasColumnType<string>("varchar(50)").IsRequired();

            b.HasData(new User { Id = 1, Name = "admin", Email = "admin.role@admin.com", Password = "admin".GetSha256(), Role = "admin", FavoriteMovie = "The Godfather" });
        }
    }
}
