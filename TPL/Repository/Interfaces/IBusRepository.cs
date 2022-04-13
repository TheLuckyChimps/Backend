using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Entities;

namespace TPL.Repository.Interfaces
{
    public interface IBusRepository
    {
        Task<Bus> InsertAsync(Bus Bus, Guid userId);
        Task<List<Bus>> GetAllAsync();
        Task<Guid> DeleteAsync(Guid id);
        Task<Bus> UpdateAsync(Bus Bus);
        Task<Bus> GetByIdAsync(Guid id);
    }
}
