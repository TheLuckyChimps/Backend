using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Entities;
using TPL.Database;
using TPL.Repository.Interfaces;

namespace TPL.Repository
{
    public class LineRepository : ILineRepository
    {
        private readonly WebApiContext context;
        private readonly DbSet<Route> dbSet;
        public LineRepository(WebApiContext context)
        {
            this.context = context;
            dbSet = context.Set<Route>();
        }

        public async Task<Route> GetByIdAsync(Guid id)
        {
            var Route = await dbSet.Where(e => e.Id == id).FirstOrDefaultAsync();
            return Route;
        }

        public async Task<List<Route>> GetAllRoutesAsync()
        {
            var Routes = await dbSet.Where(e => e.IsDeleted == false).ToListAsync();
            return Routes;
        }

        public async Task<Route> InsertAsync(Route Route, Guid userId)
        {
            Route.OnCreate(userId);
            var addedRoute = (await dbSet.AddAsync(Route)).Entity;
            await context.SaveChangesAsync();

            return addedRoute;
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            var Route = await dbSet.FindAsync(id);
            Route.SoftDelete();
            await context.SaveChangesAsync();

            return Route.Id;
        }

        public async Task<Route> UpdateAsync(Route RouteUpdate)
        {
            dbSet.Update(RouteUpdate);
            await context.SaveChangesAsync();

            return RouteUpdate;
        }
    }
}
