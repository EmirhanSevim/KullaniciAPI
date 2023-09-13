namespace SuperHeroAPI.Services.KullaniciService
{
    public interface IKullaniciService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetSingleUser(int id);
        Task<List<User>?> AddUser(User hero);
        Task<List<User>?> UpdateUser(int id, User request);
        Task<List<User>?> DeleteUser(int id);
        //Task<List> GetUser(string fullname, string password);
        Task<User> GetUser(string username, string password);
    }
}
