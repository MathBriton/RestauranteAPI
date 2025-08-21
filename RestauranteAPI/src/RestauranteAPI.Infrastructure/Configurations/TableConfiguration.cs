using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteAPI.Infrastructure.Configurations
{
    public class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.ToTable("Tables");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Number)
                   .IsRequired();

            builder.Property(t => t.IsOpen)
                   .IsRequired();

            builder.HasMany(t => t.Orders)
                   .WithOne(o => o.Table)
                   .HasForeignKey(o => o.TableId);
        }
    }
}
