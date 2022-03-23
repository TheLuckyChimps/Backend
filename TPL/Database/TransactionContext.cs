using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Entities;

namespace TPL.Database
{
    public class TransactionContext : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(ti => ti.Id);

            builder.Property(ti => ti.ProductId);

            builder.Property(ti => ti.UserId);

            builder.Property(ti => ti.CreatedAt);

            builder.Property(ti => ti.CreatedBy);

            builder.Property(ti => ti.UpdatedAt);

            builder.Property(ti => ti.UpdatedBy);

            builder.Property(ti => ti.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
