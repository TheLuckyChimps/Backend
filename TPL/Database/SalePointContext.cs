using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Entities;

namespace TPL.Database
{
    public class SalePointContext : IEntityTypeConfiguration<SalePoint>
    {
        public void Configure(EntityTypeBuilder<SalePoint> builder)
        {
            builder.HasKey(ti => ti.Id);

            builder.Property(ti => ti.Name);

            builder.Property(ti => ti.Address);

            builder.Property(ti => ti.Longitude);

            builder.Property(ti => ti.Latitude);

            builder.Property(ti => ti.SalePointType);

            builder.Property(ti => ti.CreatedAt);

            builder.Property(ti => ti.CreatedBy);

            builder.Property(ti => ti.UpdatedAt);

            builder.Property(ti => ti.UpdatedBy);

            builder.Property(ti => ti.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
