using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TPL.Data.Atributes;
using TPL.Data.Dtos;
using TPL.Servicies;
using TPL.Servicies.Interfaces;

namespace TPL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> UserRegister(UserCreateDto user)
        {
            var response = await userService.CreateUser(user);
            return Ok(response);
        }

        [JwtAuthorizeAttribute]
        [HttpGet("GetAll")]
        public async Task<IActionResult> UserGetAll(string token)
        {

            var response = await userService.GetAllUsers(token);
            return Ok(response);
        }

        [JwtAuthorizeAttribute]
        [HttpDelete("DeleteById")]
        public async Task<IActionResult> UserDelete(Guid id)
        {

            var response = await userService.DeleteUser(id);
            return Ok(response);

        }

        [JwtAuthorizeAttribute]
        [HttpPut("Update:{id}")]
        public async Task<IActionResult> UserUpdate(Guid id, UserUpdateDto dto)
        {

            var response = await userService.UpdateUser(dto, id);
            return Ok(response);
        }

        [JwtAuthorizeAttribute]
        [HttpGet("Get:{id}")]
        public async Task<IActionResult> UserGetById(Guid id)
        {

            var response = await userService.GetById(id);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPut("Update Password")]
        public async Task<IActionResult> ResetPassword(string email, string newPassword)
        {

            var response = await userService.ResetUserPassword(newPassword, email);
            return Ok(response);


        }

        //[AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate(UserAuthenticateDto model)
        {
            UserAuthenticateResponseDto response = await userService.Authenticate(model);
            string jsonResponse = JsonSerializer.Serialize(response);

            if (response.Result != "Ok")
                return BadRequest(response.Result);
            return Ok(jsonResponse);
        }
    }
}
