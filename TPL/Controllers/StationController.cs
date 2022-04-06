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
    }
}
