using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtAuthDemo.Models;

namespace JwtAuthDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (IsValidUser(model))
            {
                var token = GenerateJwtToken(model.Username, Get_config());
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }

        // Simple user check (demo only)
        private bool IsValidUser(LoginModel model)
        {
            return model.Username == "admin" && model.Password == "password";
        }

        private IConfiguration Get_config()
        {
            return _config;
        }

        // Generate JWT token using config key
        private string GenerateJwtToken(string username, IConfiguration _config)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "Admin")  // for question 3
            };

            
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
            //if (key.Length < 32)
            //{
              //  throw new Exception("JWT Key must be at least 32 characters for HS256.");
            //}

            var securityKey = new SymmetricSecurityKey(key);
            var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_config["Jwt:DurationInMinutes"])),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
