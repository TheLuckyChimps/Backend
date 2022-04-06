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
    public class StationRepository : IStationRepository
    {
        private readonly WebApiContext context;
        private readonly DbSet<Station> dbSet;
        public StationRepository(WebApiContext context)
        {
            this.context = context;
            dbSet = context.Set<Station>();
        }

        public async Task<Station> GetByIdAsync(Guid id)
        {
            var Station = await dbSet.Where(e => e.Id == id).FirstOrDefaultAsync();
            return Station;
        }

        public async Task<List<Station>> GetAllStationsAsync()
        {
            var Stations = await dbSet.Where(e => e.IsDeleted == false).ToListAsync();
            return Stations;
        }

        public async Task<Station> InsertAsync(Station Station,Guid userId)
        {
            Station.OnCreate(userId);
            var addedStation = (await dbSet.AddAsync(Station)).Entity;
            await context.SaveChangesAsync();

            return addedStation;
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            var Station = await dbSet.FindAsync(id);
            Station.SoftDelete();
            await context.SaveChangesAsync();

            return Station.Id;
        }

        public async Task<Station> UpdateAsync(Station StationUpdate)
        {
            dbSet.Update(StationUpdate);
            await context.SaveChangesAsync();

            return StationUpdate;
        }
    }
}
