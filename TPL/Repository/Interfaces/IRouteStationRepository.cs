using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Entities;

namespace TPL.Services.Interfaces
{
    public interface IRouteStationRepository
    {
        Task<RouteStation> InsertAsync(RouteStation Station);
        Task<List<RouteStation>> GetAllStationsAsync();
        Task<Guid> DeleteAsync(Guid id);
        Task<RouteStation> UpdateAsync(RouteStation StationUpdate);
        Task<RouteStation> GetByIdAsync(Guid id);
    }
}
