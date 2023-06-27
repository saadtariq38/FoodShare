using FoodShare.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodShare.Interfaces
{
    public interface IShareService
    {
        Task<IEnumerable<Share>> GetSharesByUserId(int userId);
        Task<IEnumerable<Share>> GetAllShares();
        Task<Share> CreateShare(ShareDataModel shareData, int userId);
        Task<Share> AcceptRequest(int requestId, int shareId,int userId);
        Task<Share> EditShare(int shareId, ShareDataModel shareData, int userId);
    }
}
