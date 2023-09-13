namespace KullanıcılarAPI.Models
{
    public class Bookmark
    {
        public int id { get; set; }

        public string? title { get; set; }

        public string? url { get; set; }

        public int categoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual User? User { get; set; }

        public string description { get; set; }

        public int? userId { get; set; }

        public string? created_at { get; set; }

    }
}
