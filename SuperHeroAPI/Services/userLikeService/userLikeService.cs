using KullanıcılarAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KullanıcılarAPI.Services.userLikeService
{
    public class UserLikeService : IuserLikeService 
    {

        private readonly DataContext _context;
        public UserLikeService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<userLike>?> AddUserLike(userLike _userLike)
        {
            _context.UsersLike.Add(_userLike);
            await _context.SaveChangesAsync();
            return await GetAllUserLikes();
        }

        public async Task<List<userLike>?> DeleteUserLike(int id)
        {
            var userLikes = await _context.UsersLike.FindAsync(id);
            if (userLikes == null) return null;

            _context.UsersLike.Remove(userLikes);
            await _context.SaveChangesAsync();
            return await GetAllUserLikes();
        }

        public async Task<List<userLike>> GetAllUserLikes()
        {
            var userLikes = await _context.UsersLike.ToListAsync();
            return userLikes;
        }

        public async Task<userLike> GetSingleUserLike(int id)
        {
            var userLikes = await _context.UsersLike.FindAsync(id);
            if (userLikes == null) return null;
            return userLikes;
        }
        public async Task<List<userLike>> GetLikeByUser()
        {
            return await _context.UsersLike
                 .Include(x => x.Bookmark.User)
                 .Include(x => x.Bookmark.Category)
                 .Include(x => x.User)
                 .ToListAsync();
        }

        public async Task<List<userLike>?> UpdateUserLike(int id, userLike request)
        {
            var userLike = await _context.UsersLike.FindAsync(id);
            if (userLike == null) return null;

            userLike.bookmarkId = request.bookmarkId;
            userLike.userId = request.userId;
            userLike.Id = request.Id;
            await _context.SaveChangesAsync();

            return await GetAllUserLikes();
        }
    }
}
