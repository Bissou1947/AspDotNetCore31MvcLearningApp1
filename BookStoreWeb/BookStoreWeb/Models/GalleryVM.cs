namespace BookStoreWeb.Models
{
    public class GalleryVM
    {
        public int id { get; set; }
        public string name { get; set; }
        public string photoPath { get; set; }
        public int? bookId { get; set; }
    }
}
