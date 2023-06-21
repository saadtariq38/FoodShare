using FoodShare.Data;
using FoodShare.Interfaces;
using FoodShare.Models;


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
            return true;
        }

        public async Task<bool> LoginUser(LoginDataModel loginData)
        {
            return true;
        }
    }
}
