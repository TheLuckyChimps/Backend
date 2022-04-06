using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Dtos.RouteStationDtos;
using TPL.Data.Entities;

namespace TPL.Services.Interfaces
{
    public interface IRouteStationService
    {
        Task<RouteStationResponseDto> CreateRouteStation(RouteStationCreateDto stationDto, string token);
    }
}
