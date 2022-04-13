using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Entities;
using TPL.Database;
using TPL.Services.Interfaces;

namespace TPL.Repository
{
    public class RouteStationRepository : IRouteStationRepository
    {
        private readonly WebApiContext context;
        private readonly DbSet<RouteStation> dbSet;
        public RouteStationRepository(WebApiContext context)
        {
            this.context = context;
            dbSet = context.Set<RouteStation>();
        }

        public Task<Guid> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RouteStation>> GetAllStationsAsync()
        {
            var routeStations = await dbSet.Where(e => e.IsDeleted == false).ToListAsync();
            return routeStations;
        }

        public Task<RouteStation> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<RouteStation> InsertAsync(RouteStation routeStation)
        {
            //Station.OnCreate(userId);
            var addedrouteStation = (await dbSet.AddAsync(routeStation)).Entity;
            await context.SaveChangesAsync();

            return addedrouteStation;
        }

        public Task<RouteStation> UpdateAsync(RouteStation StationUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
