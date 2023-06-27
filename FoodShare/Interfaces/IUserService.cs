using FoodShare.Models;


namespace FoodShare.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterUser(User user);
        Task<User> LoginUser(LoginDataModel loginData);
        Task<User> GetUserDetailsById(int userId);
        Task<User> UpdateUserDetails(UserEditModel userData, int userId);
    }
}
