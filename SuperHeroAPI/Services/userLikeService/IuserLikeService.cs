using KullanicilarAPI.Models;

namespace KullanicilarAPI.Services.userLikeService
{
    public interface IuserLikeService
    {
        Task<List<userLike>> GetAllUserLikes();
        Task<userLike> GetSingleUserLike(int id);
        Task<List<userLike>?> AddUserLike(userLike like);
        Task<List<userLike>?> UpdateUserLike(int id, userLike request);
        Task<List<userLike>?> DeleteUserLike(int id);
        Task<List<userLike>> GetLikeByUser();
    }
}
