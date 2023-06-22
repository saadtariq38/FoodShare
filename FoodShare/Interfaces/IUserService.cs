using FoodShare.Models;


namespace FoodShare.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterUser(User user);
        Task<User> LoginUser(LoginDataModel loginData);
    }
}
