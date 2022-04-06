using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Atributes;
using TPL.Data.Common;
using TPL.Data.Dtos.StationDtos;
using TPL.Data.Entities;
using TPL.Data.Enums;
using TPL.Repository.Interfaces;
using TPL.Services.Interfaces;

namespace TPL.Services
{
    public class StationService : IStationService
    {
        //private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly AppSettings appSettings;
        private readonly IStationRepository stationRepository;
        //private readonly IConfigurationService

        public StationService(IStationRepository stationRepository, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            this.stationRepository = stationRepository;
            this.mapper = mapper;
            this.appSettings = appSettings.Value;
        }

        public async Task<StationResponseDto> CreateStation(StationCreateDto stationDto, string token)
        {
            Guid empty = new Guid("00000000-0000-0000-0000-000000000000");
            var line = new Route()
            {
                Id = empty
            };
            var auth = await GetUserFromToken(token);
            if (auth.Role == UserRole.Admin.ToString())
            {
                // get lines
                var station = mapper.Map<StationCreateDto, Station>(stationDto);
                //station.Lines.Add(line);
                //station.Line
                var createdStation = await stationRepository.InsertAsync(station, auth.Id);
                var result = mapper.Map<Station, StationResponseDto>(createdStation);

                return result;
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
