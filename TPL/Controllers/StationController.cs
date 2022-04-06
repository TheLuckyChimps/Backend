using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Atributes;
using TPL.Data.Dtos.StationDtos;
using TPL.Services.Interfaces;

namespace TPL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StationController : Controller
    {
        private readonly IStationService stationService;
        public StationController(IStationService stationService)
        {
            this.stationService = stationService;
        }


        [JwtAuthorizeAttribute]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateStation(StationCreateDto stationDto, string token)
        {
            var response = await stationService.CreateStation(stationDto, token);
            return Ok(response);
        }

        [JwtAuthorizeAttribute]
        [HttpGet("Get-All")]
        public async Task<IActionResult> GetAllStations(string token)
        {
            var response = await stationService.GetAllStations(token);
            return Ok(response);
        }

        [JwtAuthorizeAttribute]
        [HttpDelete("DeleteById")]
        public async Task<IActionResult> DeleteStation(Guid id, string token)
        {
            await stationService.DeleteStations(id, token);
            return Ok();
        }
        [JwtAuthorizeAttribute]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateStation(StationUpdateDto dto, string token)
        {

            var response = await stationService.UpdateStation(dto, token);
            return Ok(response);
        }
    }
}
