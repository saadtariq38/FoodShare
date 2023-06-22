using BCrypt.Net;
using FoodShare.Interfaces;
using FoodShare.Models;
using FoodShare.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Bcrypt = BCrypt.Net.BCrypt;



namespace FoodShare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        // Register endpoint
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            
            bool registrationResult = await _userService.RegisterUser(user);

            if (registrationResult)
            {
                if(_configuration["AppSettings:Token"] == null)
                {
                    return BadRequest(new { Error = "Token key is null" });
                }
                string token = CreateToken(user.UserId, user.Role, _configuration["AppSettings:Token"]);
                return Ok(new { Token = token });
            }
            else
            {
                return BadRequest(new { Error = "Registration failed" });
            }
        }

        private string CreateToken(int userId, string role, string configuration)
        {
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            var tokenOptions = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            

            return tokenString;
        }




        // Login endpoint
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDataModel loginData)
        {
            User user = await _userService.LoginUser(loginData);

            if (user != null)
            {
                // Validate the password using Bcrypt.NET.Next
                bool isPasswordValid = Bcrypt.Verify(loginData.Password, user.Password);
                if (!isPasswordValid)
                {
                    return Unauthorized(new { Error = "invalid credentials" });
                }

                // Authentication successful, generate and return a JWT token

                string token = CreateToken(user.UserId, user.Role, _configuration["AppSettings:Token"]);

                return Ok(new { Token = token });

            } else
            {
                return NotFound(new { Error = "User does not exist" });
            }

            
        }



    }
}
