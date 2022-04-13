using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Dtos.BusDtos;

namespace TPL.Services.Interfaces
{
    public interface IBusService
    {
        Task<BusResponseDto> CreateBus(BusCreateDto dto, string token);
        Task<List<BusResponseDto>> GetAllBuses(string token);
        Task DeleteBus(Guid id, string token);
        Task<BusResponseDto> UpdateBus(BusUpdateDto dto, string token);
    }
}
