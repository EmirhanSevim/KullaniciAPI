using KullanıcılarAPI.Models;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Services.KullanıcıService;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public class KullaniciService : IKullaniciService
    {

        private readonly DataContext _context;

        public KullaniciService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<User>?> AddUser(User hero)
        {
            _context.Users.Add(hero);
            await _context.SaveChangesAsync();
            return await GetAllUsers();
        }
        public async Task<User> GetUser(string username,string password) 
        {
            var user =await _context.Users.FirstOrDefaultAsync(u=>u.username==username && u.password==password);
            return user;
        }

        public async Task<List<User>?> DeleteUser(int id)
        {   
            var kullanıcı = await _context.Users.FindAsync(id);
            if (kullanıcı == null) return null;

            _context.Users.Remove(kullanıcı);
            await _context.SaveChangesAsync();
            return await GetAllUsers();
        }

        public async Task<List<User>> GetAllUsers()
        {
            var heroes = await _context.Users.ToListAsync();
            return heroes;
        }


        public async Task<User> GetSingleUser(int id)
        {
            var hero = await _context.Users.FindAsync(id);
            if (hero is null) return null;
            return hero;
        }

        public async Task<List<User>?> UpdateUser(int id, User request)
        {
            var kullanıcı = await _context.Users.FindAsync(id);
            if (kullanıcı == null) return null;

            kullanıcı.username = request.username;
            kullanıcı.password = request.password;
            kullanıcı.fullname = request.fullname;
            await _context.SaveChangesAsync();

            return await GetAllUsers();
        }

    }
}




