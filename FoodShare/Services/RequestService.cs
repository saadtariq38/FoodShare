using FoodShare.Data;
using FoodShare.Interfaces;
using FoodShare.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FoodShare.Services
{
    public class RequestService : IRequestService
    {
        private readonly ApplicationDbContext _context;

        public RequestService(ApplicationDbContext context) {
            _context = context;
        }
        
        public async Task<Request> CreateRequest(RequestDataModel requestData, int userId)
        {
            Request request = new Request();
            request.UserId = userId;

            //checking if share being made request to is the users or not
            var share = await _context.Shares.FirstOrDefaultAsync(s => s.ShareId == requestData.ShareId);
            if (share.UserId == userId)
            {
                return null;
            }

            //setting all request attributes
            request.ShareId = requestData.ShareId;
            request.HoursToPickup = requestData.HoursToPickup;
            request.RequestStatus = "Pending";

            Console.WriteLine(request.HoursToPickup);
            Console.WriteLine("--------------------------------------");

            // Add the request to the database
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();

            return request;
        }

        public async Task<IEnumerable<Request>> GetRequestsByShareId(int shareId,int userId)
        {
            // Check if the share and all its requests belong to the user
            bool shareBelongsToUser = CheckShareBelongsToUser(shareId, userId);
            Console.WriteLine("Inside service--------------------------------");
            Console.WriteLine(shareBelongsToUser);
            if (!shareBelongsToUser)
            {
                return null; // User does not have access to the share or its requests
            }
            return await _context.Requests.Where(r => r.ShareId == shareId).ToListAsync();
        }

        public bool CheckShareBelongsToUser(int shareId, int userId) { return _context.Shares.Any(s => s.ShareId == shareId && s.UserId == userId); }
        
        
    }
}
