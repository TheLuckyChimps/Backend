using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Entities;

namespace TPL.Repository.Interfaces
{
    public interface ILineRepository
    {
        Task<Route> InsertAsync(Route Route, Guid userId);
        Task<List<Route>> GetAllRoutesAsync();
        Task<Guid> DeleteAsync(Guid id);
        Task<Route> UpdateAsync(Route RouteUpdate);
        Task<Route> GetByIdAsync(Guid id);
    }
}
