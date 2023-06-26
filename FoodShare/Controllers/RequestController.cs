using FoodShare.Interfaces;
using FoodShare.Models;
using FoodShare.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FoodShare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestsService;

        public RequestController(IRequestService requestsService) {
               _requestsService = requestsService;
        }

        [HttpPost("create")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> CreateRequest([FromBody] RequestDataModel requestData)
        {
            // Retrieve the UserId from the token
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var newRequest = await _requestsService.CreateRequest(requestData, userId);

            if (newRequest == null)
            {
                return BadRequest(new { Error = "Cannot request your own share or request creation failed" });
            }

            return Ok(newRequest);

        }

        [HttpGet("requests")]
        [Authorize(Roles = "1,2")]
        public async Task<IActionResult> GetRequestsForShare([FromQuery] int shareId)
        {
            Console.WriteLine("Inside endpoint--------------------------------");
            Console.WriteLine(shareId);
            // Retrieve the UserId from the token
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            // Retrieve the requests for the specified share ID
            var requests = await _requestsService.GetRequestsByShareId(shareId, userId);
            if(requests == null)
            {
                return Unauthorized();
            }

            return Ok(requests);
        }

    }

   
}
