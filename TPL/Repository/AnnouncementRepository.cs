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
    public class AnnouncementRepository : IAnnouncementRepository
    {

        private readonly WebApiContext context;
        private readonly DbSet<Announcement> dbSet;
        public AnnouncementRepository(WebApiContext context)
        {
            this.context = context;
            dbSet = context.Set<Announcement>();
        }

        public async Task<Announcement> GetByIdAsync(Guid id)
        {
            var announcement = await dbSet.Where(e => e.Id == id).FirstOrDefaultAsync();
            return announcement;
        }

        public async Task<List<Announcement>> GetAllUsersAsync()
        {
            var announcements = await dbSet.Where(e => e.IsDeleted == false).ToListAsync();
            return announcements;
        }
    }
}
