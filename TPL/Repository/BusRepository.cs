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
    public class BusRepository : IBusRepository
    {
        private readonly WebApiContext context;
        private readonly DbSet<Bus> dbSet;
        public BusRepository(WebApiContext context)
        {
            this.context = context;
            dbSet = context.Set<Bus>();
        }

        public async Task<Bus> GetByIdAsync(Guid id)
        {
            var Bus = await dbSet.Where(e => e.Id == id).FirstOrDefaultAsync();
            return Bus;
        }

        public async Task<List<Bus>> GetAllAsync()
        {
            var Bus = await dbSet.Where(e => e.IsDeleted == false).ToListAsync();
            return Bus;
        }

        public async Task<Bus> InsertAsync(Bus Bus, Guid userId)
        {
            Bus.OnCreate(userId);
            var addedRoute = (await dbSet.AddAsync(Bus)).Entity;
            await context.SaveChangesAsync();

            return addedRoute;
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            var Bus = await dbSet.FindAsync(id);
            Bus.SoftDelete();
            await context.SaveChangesAsync();

            return Bus.Id;
        }

        public async Task<Bus> UpdateAsync(Bus Bus)
        {
            dbSet.Update(Bus);
            await context.SaveChangesAsync();

            return Bus;
        }
    }
}
