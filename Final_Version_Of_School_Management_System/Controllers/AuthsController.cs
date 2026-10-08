using Final_Version_Of_School_Management_System.AllCustoms;
using Final_Version_Of_School_Management_System.DTOs.AuthDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Final_Version_Of_School_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthRepo _repo;

        public AuthsController(IAuthRepo repo)
        {
            _repo = repo;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestDto dto)
        {
            var token = await _repo.Login(dto);

            if (token == null)
                return Unauthorized("Unauthorized");

            return Ok(token);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequestDto dto)
        {
            var user = new Models.AppUser()
            {
                Email = dto.Email,
                Name = dto.UserName,
                Password = dto.Password,
            };

            var registered = await _repo.Register(user);

            if (registered)
                return Ok("Registered");

            return BadRequest();
        }
    }
}
