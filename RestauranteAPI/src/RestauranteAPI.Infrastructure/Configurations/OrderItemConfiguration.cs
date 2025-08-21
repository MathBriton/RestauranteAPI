using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteAPI.Domain.Entities;

namespace RestauranteAPI.Infrastructure.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(o => o.Id);

        builder.Property(o => o.CreatedAt)
               .IsRequired();

        builder.Property(o => o.IsClosed)
               .IsRequired();

        builder.HasMany(o => o.Items)
               .WithOne()
               .HasForeignKey(i => i.OrderId);

        builder.HasOne(o => o.Table)
               .WithMany(t => t.Orders)
               .HasForeignKey(o => o.TableId);
    }
}
