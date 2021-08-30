using System;
using MessageContract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infra
{
    internal class OrderMessageMap : IEntityTypeConfiguration<OrderMessage>
    {
        public void Configure(EntityTypeBuilder<OrderMessage> b)
        {
            b.ToTable(nameof(OrderMessage)).HasKey(x => x.Id);

            b.Property(x => x.CreatedAt).HasColumnType<DateTime>("date");
            b.Property(x => x.UpdatedAt).HasColumnType<DateTime>("date");
            b.Property(x => x.MessagePath).HasColumnType<string>("text");
            b.Property(x => x.Text).HasColumnType<string>("text");
            b.Property(x => x.Sender).HasColumnType<string>("text");
        }
    }
}