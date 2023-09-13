using KullanıcılarAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KullanıcılarAPI.Services.BookmarkService
{
    public class BookmarkService : IBookmarkService
    {
        private readonly DataContext _context;
        public BookmarkService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Bookmark>?> AddBookmark(Bookmark book)
        {
            _context.Bookmarks.Add(book);
            await _context.SaveChangesAsync();
            return await GetAllBookmark();
        }

        public async Task<List<Bookmark>?> DeleteBookmark(int id)
        {
            var bookmark = await _context.Bookmarks.FindAsync(id);
            if (bookmark == null) return null;

            _context.Bookmarks.Remove(bookmark);
            await _context.SaveChangesAsync();
            return await GetAllBookmark();
        }

        public async Task<List<Bookmark>> GetAllBookmark()
        {
            var Bookmarks = await _context.Bookmarks
                .Include(b=>b.Category)
                .Include(b=>b.User)
                .ToListAsync();

            return Bookmarks;
        }

        public async Task<List<Bookmark>> GetBookmarkByCategory(int categoryId)
        {
            var bookmarksInCategory = await _context.Bookmarks
                .Where(b => b.categoryId == categoryId)
                .Include(x => x.Category)   
                .Include(x => x.User)
                .ToListAsync();
            if (bookmarksInCategory == null || !bookmarksInCategory.Any())
            {
                return null;
            }

            return bookmarksInCategory;   
        }

        public async Task<Bookmark> GetSingleBookmark(int id)
        {
            var Bookmarks = await _context.Bookmarks.FindAsync(id);
            return Bookmarks;
        }

        public async Task<List<Bookmark>?> UpdateBookmark(int id, Bookmark request)
        {
            var bookkmark = await _context.Bookmarks.FindAsync(id);
            if (bookkmark == null) return null;

            bookkmark.id = request.id;
            bookkmark.description = request.description;
            bookkmark.title = request.title;
            bookkmark.url = request.url;
            bookkmark.categoryId = request.categoryId;
            bookkmark.created_at = request.created_at;
            bookkmark.userId = request.userId;
            await _context.SaveChangesAsync();

            return await GetAllBookmark();
        }

    }
}
