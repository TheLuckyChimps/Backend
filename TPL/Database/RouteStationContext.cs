using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Entities;

namespace TPL.Database
{
    public class RouteStationContext : IEntityTypeConfiguration<RouteStation>
    {
        public void Configure(EntityTypeBuilder<RouteStation> builder)
        {
            builder.HasKey(ti => ti.Id);

            builder.Property(ti => ti.StationId);

            builder.Property(ti => ti.LineId);

            builder.Property(ti => ti.CreatedAt);

            builder.Property(ti => ti.CreatedBy);

            builder.Property(ti => ti.UpdatedAt);

            builder.Property(ti => ti.UpdatedBy);

            builder.Property(ti => ti.IsDeleted)
                .HasDefaultValue(false);

            builder.HasOne(station => station.Station)
                .WithMany(routestation => routestation.RouteStation)
                .HasForeignKey(station => station.StationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(route => route.Route)
                .WithMany(routestation => routestation.RouteStation)
                .HasForeignKey(route => route.LineId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
