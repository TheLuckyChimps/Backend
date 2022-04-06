using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Dtos.StationDtos;

namespace TPL.Services.Interfaces
{
    public interface IStationService
    {
        Task<StationResponseDto> CreateStation(StationCreateDto stationDto, string token);
        Task<List<StationResponseDto>> GetAllStations(string token);
        Task DeleteStations(Guid id, string token);
        Task<StationResponseDto> UpdateStation(StationUpdateDto dto, string token);

    }
}
