using FoodShare.Interfaces;
using FoodShare.Models;
using FoodShare.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Security.Claims;

namespace FoodShare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShareController : ControllerBase
    {
        private readonly IShareService _sharesService;

        public ShareController(IShareService shareService) { 
            _sharesService = shareService;
        }

        [HttpGet]
        [Authorize] //Token needed for user Id
        public async Task<IActionResult> GetAllUserShares()
        {
            // Get the user ID from the authenticated user's claims
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            // Retrieve the shares by user ID
            IEnumerable<Share> shares = await _sharesService.GetSharesByUserId(userId);

            if(shares.Any()) {
                Console.WriteLine("Getting all user shares---------");
                return Ok(shares);
            } else {
                Console.WriteLine("Getting all user shares notfound---------");
                return NotFound(new { Error = "User has no shares" });
            }
            
        }

        [HttpGet("all")]
        [Authorize] //Token needed to view share info
        public async Task<IActionResult> GetAllShares()
        {
            IEnumerable<Share> shares = await _sharesService.GetAllShares();
            if (shares.Any())
            {
                Console.WriteLine("Getting all shares");
                return Ok(shares);
            } else
            {
                Console.WriteLine("no shares exist");
                return NotFound(new { Error = "No shares exist" });
            }
        }

        [HttpPost("create")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> CreateNewShare([FromBody] ShareDataModel shareData)
        {
            // Retrieve the UserId from the token
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            Share updatedShare = await _sharesService.CreateShare(shareData, userId);

            if (updatedShare == null)
            {
                return BadRequest(new { Error = "Creating new share failed" });
            }

            

            return Ok(updatedShare);
        }

        [HttpPost("accept")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> AcceptRequestOnShare([FromQuery] int requestId, int shareId)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            Share share = await _sharesService.AcceptRequest(requestId, shareId, userId);

            if(share == null)
            {
                return BadRequest(new { Error = "Share/Request not found or user not authorized" });
            }

            Console.WriteLine(share.Status);

            return Ok(share);

        }

        [HttpPut("edit/{shareId}")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> EditShare(int shareId, [FromBody] ShareDataModel shareData)
        {
            // Retrieve the UserId from the token
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            // Call the service method to edit the share
            Share updatedShare = await _sharesService.EditShare(shareId, shareData, userId);

            if (updatedShare == null)
            {
                return BadRequest(new { Error = "Editing share failed" });
            }

            return Ok(updatedShare);
        }


    }
}
