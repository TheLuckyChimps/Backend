using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Atributes;
using TPL.Data.Dtos.BusDtos;
using TPL.Services.Interfaces;

namespace TPL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusController : Controller
    {
        private readonly IBusService busService;
        public BusController(IBusService busService)
        {
            this.busService = busService;
        }
        [JwtAuthorizeAttribute]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateBus(BusCreateDto BusDto, string token)
        {

            var response = await busService.CreateBus(BusDto, token);
            return Ok(response);
        }

        [JwtAuthorizeAttribute]
        [HttpGet("Get-All")]
        public async Task<IActionResult> GetAllBuses(string token)
        {
            var response = await busService.GetAllBuses(token);
            return Ok(response);
        }

        [JwtAuthorizeAttribute]
        [HttpDelete("DeleteById")]
        public async Task<IActionResult> DeleteBus(Guid id, string token)
        {
            await busService.DeleteBus(id, token);
            return Ok();
        }
        [JwtAuthorizeAttribute]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateStation(BusUpdateDto dto, string token)
        {

            var response = await busService.UpdateBus(dto, token);
            return Ok(response);
        }
    }
}
