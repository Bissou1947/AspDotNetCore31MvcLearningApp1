namespace BookStoreWeb.Data
{
    public class Gallery
    {
        public int id { get; set; }
        public string name { get; set; }
        public string photoPath { get; set; }
        public int? bookId { get; set; }
        public Book Book { get; set; }
    }
}
