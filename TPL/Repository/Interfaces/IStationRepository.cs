using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Entities;

namespace TPL.Repository.Interfaces
{
    public interface IStationRepository
    {
        Task<Station> InsertAsync(Station Station, Guid userId);
        Task<List<Station>> GetAllStationsAsync();
        Task<Guid> DeleteAsync(Guid id);
        Task<Station> UpdateAsync(Station StationUpdate);
        Task<Station> GetByIdAsync(Guid id);
    }
}
