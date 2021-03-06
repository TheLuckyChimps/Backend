using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TPL.Data.Entities;

namespace TPL.Database
{
    public class WebApiContext : DbContext
    {
        public WebApiContext(DbContextOptions<WebApiContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<SalePoint> SalePoint { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Route> Lines { get; set; }
        public DbSet<Announcement> Announcement { get; set; }
        public DbSet<RouteStation> RouteStation { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            
            base.OnModelCreating(builder);
        }
    }
}
