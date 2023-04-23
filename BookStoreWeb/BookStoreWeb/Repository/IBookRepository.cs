using BookStoreWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreWeb.Repository
{
    public interface IBookRepository
    {
        Task<int> AddBook(BookVM book);
        Task<BookVM> GetBookById(int id);
        List<BookVM> GetBookByTitleOrAuthor(string title, string author);
        Task<List<BookVM>> GetBooks();
        Task<List<BookVM>> GetTopBooks(int top);
    }
}