using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.BusinessModel;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HandCarftBaseServer.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IRepositoryWrapper _repository;

        public AccountController(IConfiguration config, IRepositoryWrapper repository)
        {
            _configuration = config;
            _repository = repository;
        }



        [HttpPost]
        [Route("Account/Login")]
        public async Task<IActionResult> Login(UserLoginModel userLogin)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = _repository.Users.FindByCondition(c => c.Username == userLogin.Username && c.Hpassword == userLogin.Password)
                .Include(c => c.UserRole)
                .FirstOrDefault();

            if (user == null) return BadRequest("Invalid credentials");
            {
                //create claims details based on the user information
                var roleId = _repository.Role.FindByCondition(c => c.Id == user.UserRole.FirstOrDefault().Role)
                    .Select(c => c.Id).FirstOrDefault();
                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", user.Id.ToString()),
                    new Claim("FullName", user.FullName),
                    new Claim("UserName", user.Username),
                    new Claim("Email", user.Email),
                    new Claim("role", roleId.ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
                var res = new {token = new JwtSecurityTokenHandler().WriteToken(token), Fullname = user.FullName};
                return Ok(res);
            }

        }


    }
}

