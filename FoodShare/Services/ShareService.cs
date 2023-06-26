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
            FoodType foodType = await _context.FoodTypes.FirstOrDefaultAsync(ft => ft.TypeName == shareData.FoodType);
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

        

    }
}
