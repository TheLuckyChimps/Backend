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
    }
}
