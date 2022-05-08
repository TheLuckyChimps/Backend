using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Atributes;
using TPL.Data.Dtos.RouteStationDtos;
using TPL.Data.Entities;
using TPL.Services.Interfaces;

namespace TPL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RouteStationController : Controller
    {
        private readonly IRouteStationService routeStationService;
       
        public RouteStationController(IRouteStationService routeStationService)
        {
            this.routeStationService = routeStationService;
        }


        [JwtAuthorizeAttribute]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateStation(RouteStationCreateDto stationDto, string token)
        {

            var response = await routeStationService.CreateRouteStation(stationDto, token);
            return Ok(response);


        }

        //[JwtAuthorizeAttribute]
        [HttpGet("Get-all")]
        public async Task<IActionResult> GetAll(string token)
        {

            var response = await routeStationService.GetRouteStation(token);
            return Ok(response);


        }
    }
}
