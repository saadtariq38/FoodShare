using Bcrypt = BCrypt.Net.BCrypt;
using FoodShare.Interfaces;
using FoodShare.Models;
using Microsoft.EntityFrameworkCore;
using FoodShare.Data;
using Microsoft.AspNetCore.Identity;

namespace FoodShare.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterUser(User user)
        {
            // Hash the password
            string hashedPassword = Bcrypt.HashPassword(user.Password);
            user.Password = hashedPassword;

            // Set default values
            user.Role = "1";
            user.SharesCompleted = 0;



            // Save the user to the database
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<User> LoginUser(LoginDataModel loginData)
        {
            // Retrieve the user based on the provided email
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginData.Email);

            if (user == null)
            {
                return null; // User not found
            }


            return user;
        }

        public async Task<User> GetUserDetailsById(int userId)
        {
            var user = await _context.Users
            .Where(u => u.UserId == userId)
            .Select(u => new User
            {
                UserId = u.UserId,
                Username = u.Username,
                Email = u.Email,
                Contact = u.Contact,
                SharesCompleted = u.SharesCompleted

            })
            .FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }

            return user;



        }

        public async Task<User> UpdateUserDetails(UserEditModel userData, int userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return null;
            }

           
            user.Contact = userData.Contact;
            user.Username = userData.Username;

            await _context.SaveChangesAsync();

            return user;
        }
       
    }

}
