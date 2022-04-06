using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Atributes;
using TPL.Data.Dtos.RouteDtos;
using TPL.Services.Interfaces;

namespace TPL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RouteController : Controller
    {
        private readonly IRouteService RouteService;
        public RouteController(IRouteService RouteService)
        {
            this.RouteService = RouteService;
        }

        
        [JwtAuthorizeAttribute]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateRoute(RouteCreateDto RouteDto, string token)
        {

            var response = await RouteService.CreateRoute(RouteDto, token);
            return Ok(response);


        }
    }
}
