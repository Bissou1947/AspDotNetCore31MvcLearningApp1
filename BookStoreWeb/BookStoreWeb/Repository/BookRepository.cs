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
                new Book(){id = 1,author = "A",title = "AAA",page="100",language="en",category="Technology",description="AAA AAA AAA AAA AAA AAA AAA AAA AAA AAA AAA AAA AAA AAA AAA"},
                new Book(){id = 2,author = "B",title = "BBB",page="200",language="Arabic",category="History",description="BBB BBB BBB BBB BBB BBB BBB BBB BBB BBB BBB BBB BBB BBB BBB"},
                new Book(){id = 3,author = "C",title = "CCC",page="300",language="Turkish",category="Sports",description="CCC CCC CCC CCC CCC CCC CCC CCC CCC CCC CCC CCC CCC CCC CCC"},
            };
        }
    }
}
