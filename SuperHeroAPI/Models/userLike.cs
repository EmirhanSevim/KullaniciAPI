namespace KullanicilarAPI.Models
{
    public class userLike
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public virtual Bookmark? Bookmark { get; set; }
        public virtual User? User { get; set; }
        public int bookmarkId { get; set; }
       
    }
}
