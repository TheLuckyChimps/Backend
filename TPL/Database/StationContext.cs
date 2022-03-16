using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Entities;

namespace TPL.Database
{
    public class StationContext : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.HasKey(ti => ti.Id);

            builder.Property(ti => ti.Name)
                .IsRequired();

            builder.Property(ti => ti.Address)
                .IsRequired();

            builder.Property(ti => ti.Longitude)
               .HasMaxLength(30)
               .IsRequired();

            builder.Property(ti => ti.Latitude)
                .IsRequired();

            builder.HasMany(ti => ti.Lines)
                   .WithMany(li => li.Stations);


            builder.Property(ti => ti.CreatedAt);

            builder.Property(ti => ti.CreatedBy);

            builder.Property(ti => ti.UpdatedAt);

            builder.Property(ti => ti.UpdatedBy);

            builder.Property(ti => ti.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
