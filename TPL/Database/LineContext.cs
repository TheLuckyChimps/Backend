using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Entities;

namespace TPL.Database
{
    public class LineContext : IEntityTypeConfiguration<Line>
    {
        public void Configure(EntityTypeBuilder<Line> builder)
        {
            builder.HasKey(ti => ti.Id);

            builder.Property(ti => ti.Name)
               .HasMaxLength(30);

            builder.HasMany(ti => ti.Buses)
                .WithOne(li => li.Line)
                .HasForeignKey(f => f.LineId);


            builder.HasMany(ti => ti.Stations)
                .WithMany(li => li.Lines);

            builder.Property(ti => ti.CreatedAt);

            builder.Property(ti => ti.CreatedBy);

            builder.Property(ti => ti.UpdatedAt);

            builder.Property(ti => ti.UpdatedBy);

            builder.Property(ti => ti.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
