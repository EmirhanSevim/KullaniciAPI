namespace SuperHeroAPI.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string username { get; set; } = string.Empty;
        public string fullname { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;

    }
}
