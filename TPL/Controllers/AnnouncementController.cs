using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Atributes;
using TPL.Services.Interfaces;

namespace TPL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService announcementService;
        public AnnouncementController(IAnnouncementService announcementService)
        {
            this.announcementService = announcementService;
        }

        [JwtAuthorizeAttribute]
        [HttpGet("GetAll")]
        public async Task<IActionResult> AnnouncementGetAll()
        {

            var response = await announcementService.GetAllAnnouncements();
            return Ok(response);

        }
        [JwtAuthorizeAttribute]
        [HttpGet("GetById")]
        public async Task<IActionResult> AnnouncementGetAll(Guid id)
        {

            var response = await announcementService.GetById(id);
            return Ok(response);

        }
    }
}
