using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Dtos.RouteDtos;

namespace TPL.Services.Interfaces
{
    public interface IRouteService
    {
        Task<RouteResponseDto> CreateRoute(RouteCreateDto routeDto, string token);
        Task<List<RouteResponseDto>> GetAllStations(string token);
        Task DeleteStations(Guid id, string token);
        Task<RouteResponseDto> UpdateStation(RouteUpdateDto dto, string token);
    }
}
