using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Atributes;
using TPL.Data.Common;
using TPL.Data.Dtos.BusDtos;
using TPL.Data.Entities;
using TPL.Data.Enums;
using TPL.Repository.Interfaces;
using TPL.Services.Interfaces;

namespace TPL.Services
{
    public class BusService : IBusService
    {
        private readonly IMapper mapper;
        private readonly AppSettings appSettings;
        private readonly IBusRepository busRepository;
        //private readonly IConfigurationService

        public BusService(IBusRepository busRepository, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            this.busRepository = busRepository;
            this.mapper = mapper;
            this.appSettings = appSettings.Value;
        }

        public async Task<BusResponseDto> CreateBus(BusCreateDto busDto, string token)
        {

            var auth = await GetUserFromToken(token);
            if (auth.Role == UserRole.Admin.ToString())
            {
                // get lines
                var bus = mapper.Map<BusCreateDto, Bus>(busDto);
                //station.Lines.Add(line);
                //station.Line
                //bus.Stations.Add(defaultStation);
                var createdBus = await busRepository.InsertAsync(bus, auth.Id);
                var result = mapper.Map<Bus, BusResponseDto>(createdBus);

                return result;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        public async Task<List<BusResponseDto>> GetAllBuses(string token)
        {
            var auth = await GetUserFromToken(token);
            if (auth.Role == UserRole.Admin.ToString())
            {
                var buses = await busRepository.GetAllAsync();

                List<BusResponseDto> busesResponse = new List<BusResponseDto>();

                foreach (Bus station in buses)
                {
                    var userResponse = mapper.Map<BusResponseDto>(station);
                    busesResponse.Add(userResponse);
                }
                return busesResponse;
            }
            else
            {
                throw new NotImplementedException();
            }

        }

        public async Task DeleteBus(Guid id, string token)
        {
            var auth = await GetUserFromToken(token);
            if (auth.Role == UserRole.Admin.ToString())
            {
                await busRepository.DeleteAsync(id);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public async Task<BusResponseDto> UpdateBus(BusUpdateDto dto, string token)
        {
            var auth = await GetUserFromToken(token);
            if (auth.Role == UserRole.Admin.ToString())
            {
                var bus = await busRepository.GetByIdAsync(dto.Id);
                var busMapped = mapper.Map<BusUpdateDto, Bus>(dto, bus);
                var updatedBus = await busRepository.UpdateAsync(busMapped);
                var mappedResponse = mapper.Map<BusResponseDto>(updatedBus);
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
