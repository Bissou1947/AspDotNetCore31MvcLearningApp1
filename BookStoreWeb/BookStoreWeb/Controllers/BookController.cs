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
        public ViewResult GetBooks()
        {
            return View(_bookRepository.GetBooks());
        }
        [Route("Book-Details/{id}")]
        public ViewResult GetBookById(int id)
        {
            return View(_bookRepository.GetBookById(id));
        }

        public List<Book> GetBookByTitleOrAuthor(string title, string author)
        {
            return _bookRepository.GetBookByTitleOrAuthor(title, author);
        }
    }
}
