using BookStoreWeb.Models;
using BookStoreWeb.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookStoreWeb.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        public BookController()
        {
            _bookRepository = new BookRepository();
        }
        public IActionResult Index()
        {
            return View();
        }
        public ViewResult GetBooks()
        {
            var data =_bookRepository.GetBooks();
            return View();
        }
        public Book GetBookById(int id)
        {
            return _bookRepository.GetBookById(id);
        }

        public List<Book> GetBookByTitleOrAuthor(string title, string author)
        {
            return _bookRepository.GetBookByTitleOrAuthor(title, author);
        }
    }
}
