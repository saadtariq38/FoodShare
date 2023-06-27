using FoodShare.Data;
using FoodShare.Interfaces;
using FoodShare.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodShare.Services
{
    public class ShareService : IShareService
    {
        private readonly ApplicationDbContext _context;

        public ShareService(ApplicationDbContext context) { 
            _context = context;
        }

        public async Task<IEnumerable<Share>> GetSharesByUserId(int userId)
        {
            return await _context.Shares.Where(s => s.UserId == userId).ToListAsync();
            
        }

        public async Task<IEnumerable<Share>> GetAllShares()
        {
            return await _context.Shares.ToListAsync();
        }

        public async Task<Share> CreateShare(ShareDataModel shareData, int userId)
        {
            Share share = new Share();
            share.UserId = userId;

            // Get the FoodType and Allergen entities by their ids
            FoodType foodType = await _context.FoodTypes.FirstOrDefaultAsync(ft => ft.TypeName == shareData.FoodType);  // passing string names for both
            Allergen allergen = await _context.Allergens.FirstOrDefaultAsync(a => a.Name == shareData.Allergen);

            // Check if the FoodType exists and set the corresponding ID
            if (foodType != null)
            {
                share.FoodTypeId = foodType.TypeId;
            }
            // Check if the Allergen exists and set the corresponding ID
            if (allergen != null)
            {
                    share.AllergenId = allergen.AllergenId;
            }

            // Set the values for the share object
            share.Status = "Available";
            share.Name = shareData.Name;
            share.PickupLocation = shareData.PickupLocation;
            share.FeedCount = shareData.FeedCount;
            share.Image = shareData.Image;
            share.Description = shareData.Description;


            Console.WriteLine(share.Name);
            Console.WriteLine("--------------------------------------");

            // Add the share to the database
            _context.Shares.Add(share);
            await _context.SaveChangesAsync();

            return share;
        }

        public async Task<Share> AcceptRequest(int requestId, int shareId, int userId)
        {
            var share = await _context.Shares.FirstOrDefaultAsync(s => s.ShareId == shareId);
            var request = await _context.Requests.FirstOrDefaultAsync(r => r.RequestId == requestId);

            if (share.UserId != userId)
            {
                return null; // Handle case when share doesn't belong to the user
            }

            if (share == null || request == null)
            {
                return null; // Handle case when share or request is not found
            }

            // Update the statuses
            share.Status = "Claimed";
            request.RequestStatus = "Accepted";

            await UpdateOtherRequestsStatus(shareId, requestId);

            return share;
        }

        public async Task UpdateOtherRequestsStatus(int shareId, int acceptedRequestId)
        {
            // Retrieve all requests for the same share except the accepted one
            var requests = await _context.Requests
                .Where(r => r.ShareId == shareId && r.RequestId != acceptedRequestId)
                .ToListAsync();

            // Update the status of each request to 'Rejected'
            foreach (var request in requests)
            {
                request.RequestStatus = "Rejected";
            }
        }

        public async Task<Share> EditShare(int shareId, ShareDataModel shareData, int userId)
        {
            // Retrieve the share from the database
            Share share = await _context.Shares.FirstOrDefaultAsync(s => s.ShareId == shareId && s.UserId == userId);

            if (share == null)
            {
                return null;
            }

            // Get the FoodType and Allergen entities by their names
            FoodType foodType = await _context.FoodTypes.FirstOrDefaultAsync(ft => ft.TypeName == shareData.FoodType); // passing string names for both
            Allergen allergen = await _context.Allergens.FirstOrDefaultAsync(a => a.Name == shareData.Allergen);

            // Check if the FoodType exists and set the corresponding ID
            if (foodType != null)
            {
                share.FoodTypeId = foodType.TypeId;
            }
            // Check if the Allergen exists and set the corresponding ID
            if (allergen != null)
            {
                share.AllergenId = allergen.AllergenId;
            }

            // Update only the attributes that are provided in the shareData object
            if (!string.IsNullOrEmpty(shareData.Name))
            {
                share.Name = shareData.Name;
            }

            if (!string.IsNullOrEmpty(shareData.PickupLocation))
            {
                share.PickupLocation = shareData.PickupLocation;
            }

            if (shareData.FeedCount > 0)
            {
                share.FeedCount = shareData.FeedCount;
            }

            if (!string.IsNullOrEmpty(shareData.Image))
            {
                share.Image = shareData.Image;
            }

            if (!string.IsNullOrEmpty(shareData.Description))
            {
                share.Description = shareData.Description;
            }


            // Update the share in the database
            _context.Shares.Update(share);
            await _context.SaveChangesAsync();

            return share;
        }

    }
}
