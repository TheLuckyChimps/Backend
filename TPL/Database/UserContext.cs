using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Entities;

namespace TPL.Database
{
    public class UserContext : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(ti => ti.Id);

            builder.Property(ti => ti.Email)
                .IsRequired();

            builder.Property(ti => ti.Surname)
                .IsRequired();

            builder.Property(ti => ti.Address)
                .IsRequired();

            builder.Property(ti => ti.Password)
                .IsRequired();

            builder.Property(ti => ti.Name)
               .HasMaxLength(30)
               .IsRequired();

            builder.Property(ti => ti.Role)
                .HasMaxLength(20);

            builder.Property(ti => ti.CreatedAt);

            builder.Property(ti => ti.CreatedBy);

            builder.Property(ti => ti.UpdatedAt);

            builder.Property(ti => ti.UpdatedBy);

            builder.Property(ti => ti.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
