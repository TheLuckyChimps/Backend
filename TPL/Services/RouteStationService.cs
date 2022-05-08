using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Atributes;
using TPL.Data.Dtos.RouteDtos;
using TPL.Data.Dtos.RouteStationDtos;
using TPL.Data.Dtos.StationDtos;
using TPL.Data.Entities;
using TPL.Repository.Interfaces;
using TPL.Services.Interfaces;

namespace TPL.Services
{
    public class RouteStationService : IRouteStationService
    {
        private readonly IMapper mapper;
        private readonly AppSettings appSettings;
        private readonly IRouteStationRepository routeStationRepository;
        private readonly ILineRepository routeRepository;
        private readonly IStationRepository stationRepository;
        //private readonly IConfigurationService

        public RouteStationService(IRouteStationRepository routeStationRepository, ILineRepository routeRepository, IStationRepository stationRepository, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            this.routeStationRepository = routeStationRepository;
            this.routeRepository = routeRepository;
            this.stationRepository = stationRepository;
            this.mapper = mapper;
            this.appSettings = appSettings.Value;
        }
        public async Task<RouteStationResponseDto> CreateRouteStation(RouteStationCreateDto routeStationDto, string token)
        {
            var routeStation = new RouteStation
            {
                StationId = routeStationDto.StationId,
                LineId = routeStationDto.RouteId
            };
            var response = new RouteStationResponseDto();
            var addedRouteStation = await routeStationRepository.InsertAsync(routeStation);
            var route = await routeRepository.GetByIdAsync(addedRouteStation.LineId);
            var station = await stationRepository.GetByIdAsync(addedRouteStation.StationId);
            var mappedStation = mapper.Map<Station, StationResponseDto>(station);
            var mappedRoute = mapper.Map<Route, RouteResponseDto>(route);
            response.Route = mappedRoute;
            response.Station = mappedStation;
            response.Id = addedRouteStation.Id;
            return response;
        }

        public async Task<List<RouteStationResponseDto>> GetRouteStation(string token)
        {
            var respone = new List<RouteStationResponseDto>();
            var routeStations = await routeStationRepository.GetAllStationsAsync();
            foreach (var item in routeStations)
            {
                var routeStation = new RouteStationResponseDto();
                var route = await routeRepository.GetByIdAsync(item.LineId);
                var station = await stationRepository.GetByIdAsync(item.StationId);
                var mappedStation = mapper.Map<Station, StationResponseDto>(station);
                var mappedRoute = mapper.Map<Route, RouteResponseDto>(route);
                routeStation.Route = mappedRoute;
                routeStation.Station = mappedStation;
                routeStation.Id = item.Id;
                respone.Add(routeStation);
            }
            return respone;
        }

        //public async Task<>
    }
}
