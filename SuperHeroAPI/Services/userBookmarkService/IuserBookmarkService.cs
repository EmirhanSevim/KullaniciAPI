using KullanicilarAPI.Models;

namespace KullanicilarAPI.Services.userBookmarkService
{
    public interface IuserBookmarkService
    {
        Task<List<userBookmark>> GetAllUserBookmarks();
        Task<userBookmark> GetSingleUserBookmark(int id);
        Task<List<userBookmark>?> AddUserBookmark(userBookmark _userbookmark);
        Task<List<userBookmark>?> UpdateUserBookmark(int id, userBookmark request);
        Task<List<userBookmark>?> DeleteUserBookmark(int id);
    }
}
