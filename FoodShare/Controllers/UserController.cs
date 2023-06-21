using FoodShare.Interfaces;
using FoodShare.Models;
using FoodShare.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodShare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Register endpoint
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            bool registrationResult = await _userService.RegisterUser(user);

            if (registrationResult)
            {
                return Ok("Registration successful");
            }
            else
            {
                return BadRequest("Registration failed");
            }
        }

        // Login endpoint
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDataModel loginData)
        {
            bool loginResult = await _userService.LoginUser(loginData);

            if (loginResult)
            {
                return Ok("Login successful");
            }
            else
            {
                return Unauthorized("Invalid email or password");
            }
        }



    }
}
