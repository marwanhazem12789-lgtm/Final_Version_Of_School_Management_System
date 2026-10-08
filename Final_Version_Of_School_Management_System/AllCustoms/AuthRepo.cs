using Final_Version_Of_School_Management_System.DTOs.AuthDTOs;
using Final_Version_Of_School_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Final_Version_Of_School_Management_System.AllCustoms
{
    public class AuthRepo : IAuthRepo
    {
        private readonly Context _context;
        private readonly IConfiguration _configuration;
        public AuthRepo(Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<string> Login(DTOs.AuthDTOs.LoginRequestDto dto)
        {
            var user = await _context.appUsers.FirstOrDefaultAsync(a => a.Name == dto.UserName);

            if (user == null)
                return null;

            if (user.Password == dto.Password)
                return TokenGenerator(user);

            return null;

        }

        public async Task<bool> Register(AppUser user)
        {
            var existingEmail = await _context.appUsers.AnyAsync(a => a.Email == user.Email);

            if (existingEmail)
                return false;

            await _context.appUsers.AddAsync(user);
            await _context.SaveChangesAsync();

            return true;
        }


        private string TokenGenerator(AppUser user)
        {

            var claims = new List<Claim>
            {
                new Claim("Name",user.Name),
                new Claim("Email",user.Email),

            };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Key"]));

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var JWTToken = new JwtSecurityToken(
                     issuer: _configuration["JWT:Issuer"],
                     audience: _configuration["JWT:Audience"],
                     expires: DateTime.Now.AddHours(Convert.ToDouble(_configuration["JWT:ExpirationInHours"])),
                     claims: claims,
                     signingCredentials: signingCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(JWTToken);

            return token;
        }

    }
}
