using KullanıcılarAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KullanıcılarAPI.Services.userBookmarkService
{
    public class userBookmarkService : IuserBookmarkService
    {

        private readonly DataContext _context;
        public userBookmarkService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<userBookmark>?> AddUserBookmark(userBookmark _userBookmark)
        {
            _context.UserBookmark.Add(_userBookmark);
            await _context.SaveChangesAsync();
            return await GetAllUserBookmarks();
        }

        public async Task<List<userBookmark>?> DeleteUserBookmark(int id)
        {
            var userBookmarks = await _context.UserBookmark.FindAsync(id);
            if (userBookmarks == null) return null;

            _context.UserBookmark.Remove(userBookmarks);
            await _context.SaveChangesAsync();
            return await GetAllUserBookmarks();
        }

        public async Task<List<userBookmark>> GetAllUserBookmarks()
        {
            var userBookmarks = await _context.UserBookmark.ToListAsync();
            return userBookmarks;
        }

        public async Task<userBookmark> GetSingleUserBookmark(int id)
        {
            var userBookmarks = await _context.UserBookmark.FindAsync(id);
            if (userBookmarks == null) return null;
            return userBookmarks;   
        }

        public async Task<List<userBookmark>?> UpdateUserBookmark(int id, userBookmark request)
        {
            var userBookmark = await _context.UserBookmark.FindAsync(id);
            if (userBookmark == null) return null;

            userBookmark.bookmarkId = request.bookmarkId;
            userBookmark.userId = request.userId;
            userBookmark.Id = request.Id;
            await _context.SaveChangesAsync();

            return await GetAllUserBookmarks();
        }
    }
}
