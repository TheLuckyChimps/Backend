using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Entities;

namespace TPL.Repository.Interfaces
{
    public interface IAnnouncementRepository
    {
        Task<Announcement> GetByIdAsync(Guid id);
        Task<List<Announcement>> GetAllUsersAsync();
    }
}
