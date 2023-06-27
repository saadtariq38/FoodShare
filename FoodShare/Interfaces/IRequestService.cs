using FoodShare.Models;

namespace FoodShare.Interfaces
{
    public interface IRequestService
    {
        Task<Request> CreateRequest(RequestDataModel request, int userId);
        Task<IEnumerable<Request>> GetRequestsByShareId(int shareId, int userId);
        bool CheckShareBelongsToUser(int shareId, int userId);
        Task<Request> DeleteRequest(int requestId, int shareId, int userId);
        Task<Share> GetShareById(int shareId);
    }
}
