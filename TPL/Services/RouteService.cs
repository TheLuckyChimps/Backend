using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Atributes;
using TPL.Data.Common;
using TPL.Data.Dtos.RouteDtos;
using TPL.Data.Entities;
using TPL.Data.Enums;
using TPL.Repository.Interfaces;
using TPL.Services.Interfaces;

namespace TPL.Services
{
    public class RouteService : IRouteService
    {
        private readonly IMapper mapper;
        private readonly AppSettings appSettings;
        private readonly ILineRepository lineRepository;
        private readonly IStationRepository stationRepository;
        //private readonly IConfigurationService

        public RouteService(ILineRepository lineRepository, IStationRepository stationRepository, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            this.lineRepository = lineRepository;
            this.stationRepository = stationRepository;
            this.mapper = mapper;
            this.appSettings = appSettings.Value;
        }

        public async Task<RouteResponseDto> CreateRoute(RouteCreateDto routeDto, string token)
        {
            Guid empty = new Guid("00000000-0000-0000-0000-000000000000");
            var defaultStation = await stationRepository.GetByIdAsync(empty);
            var station = new Station()
            {
                Id = empty
            };
            var auth = await GetUserFromToken(token);
            if (auth.Role == UserRole.Admin.ToString())
            {
                // get lines
                var route = mapper.Map<RouteCreateDto, Route>(routeDto);
                //station.Lines.Add(line);
                //station.Line
                //route.Stations.Add(defaultStation);
                var createdStation = await lineRepository.InsertAsync(route, auth.Id);
                var result = mapper.Map<Route, RouteResponseDto>(createdStation);

                return result;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        public async Task<List<RouteResponseDto>> GetAllStations(string token)
        {
            var auth = await GetUserFromToken(token);
            if (auth.Role == UserRole.Admin.ToString())
            {
                var stations = await stationRepository.GetAllStationsAsync();

                List<RouteResponseDto> stationsResponse = new List<RouteResponseDto>();

                foreach (Station station in stations)
                {
                    var userResponse = mapper.Map<RouteResponseDto>(station);
                    stationsResponse.Add(userResponse);
                }
                return stationsResponse;
            }
            else
            {
                throw new NotImplementedException();
            }

        }

        public async Task DeleteStations(Guid id, string token)
        {
            var auth = await GetUserFromToken(token);
            if (auth.Role == UserRole.Admin.ToString())
            {
                await stationRepository.DeleteAsync(id);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public async Task<RouteResponseDto> UpdateStation(RouteUpdateDto dto, string token)
        {
            var auth = await GetUserFromToken(token);
            if (auth.Role == UserRole.Admin.ToString())
            {
                Station station = await stationRepository.GetByIdAsync(dto.Id);
                var userMapped = mapper.Map<RouteUpdateDto, Station>(dto, station);
                var updatedStation = await stationRepository.UpdateAsync(userMapped);
                var mappedResponse = mapper.Map<RouteResponseDto>(updatedStation);
                return mappedResponse;
            }
            else
            {
                throw new NotImplementedException();
            }
        }


        public async Task<TokenData> GetUserFromToken(string token)
        {
            var response = new TokenData();
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            response.Id = Guid.Parse(jwtSecurityToken.Claims.First(claim => claim.Type == "id").Value);
            response.Role = jwtSecurityToken.Claims.First(claim => claim.Type == "role").Value;
            //User user = await userRepository.GetByIdAsync(new Guid(id));

            return response;
        }
    }
}
