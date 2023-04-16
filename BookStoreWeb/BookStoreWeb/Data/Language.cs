using System.Collections.Generic;

namespace BookStoreWeb.Data
{
    public class Language
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        //.....relations............//
        public ICollection<Book> Book { get; set; }
    }
}
