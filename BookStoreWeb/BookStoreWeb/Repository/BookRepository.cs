using BookStoreWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreWeb.Repository
{
    public class BookRepository
    {
        public List<Book> GetBooks()
        {
            return DB_Data();
        }
        public Book GetBookById(int id)
        {
            return DB_Data().Where(a=>a.id == id).FirstOrDefault();
        }

        public List<Book> GetBookByTitleOrAuthor(string title,string author)
        {
            return DB_Data().Where(a => a.title.ToLower().Contains(title.ToLower()) || a.author.ToLower().Contains(author.ToLower())).ToList();
        }

        //.....Data....like DB....................//

        private List<Book> DB_Data()
        {
            return new List<Book>()
            {
                new Book(){id = 1,author = "A",title = "AAA"},
                new Book(){id = 2,author = "B",title = "BBB"},
                new Book(){id = 3,author = "C",title = "CCC"},
            };
        }
    }
}
