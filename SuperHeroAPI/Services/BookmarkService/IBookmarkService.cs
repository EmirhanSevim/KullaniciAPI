using KullanıcılarAPI.Models;

namespace KullanıcılarAPI.Services.BookmarkService
{
    public interface IBookmarkService
    {
        Task<List<Bookmark>> GetAllBookmark();
        Task<Bookmark> GetSingleBookmark(int id);
        Task<List<Bookmark>?> AddBookmark(Bookmark book);
        Task<List<Bookmark>?> UpdateBookmark(int id, Bookmark request);
        Task<List<Bookmark>?> DeleteBookmark(int id);
        Task<List<Bookmark>> GetBookmarkByCategory(int CategoryId);
    }
}
