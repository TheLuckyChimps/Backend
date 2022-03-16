using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Entities;

namespace TPL.Database
{
    public class BusContext : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.HasKey(ti => ti.Id);

            builder.Property(ti => ti.Name)
                .IsRequired();

            builder.Property(ti => ti.Number)
                .IsRequired();

            builder.Property(ti => ti.Driver)
               .HasMaxLength(30)
               .IsRequired();

            builder.Property(ti => ti.Type)
                .IsRequired();

            builder.HasOne(ti => ti.Line)
                   .WithMany(li => li.Buses)
                   .HasForeignKey(fk => fk.LineId);

            builder.Property(ti => ti.CreatedAt);

            builder.Property(ti => ti.CreatedBy);

            builder.Property(ti => ti.UpdatedAt);

            builder.Property(ti => ti.UpdatedBy);

            builder.Property(ti => ti.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
