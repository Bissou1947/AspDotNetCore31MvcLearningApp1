using BookStoreWeb.Models;
using BookStoreWeb.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BookStoreWeb.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _env = null;
        public BookController(BookRepository bookRepository,
            LanguageRepository languageRepository,
            IWebHostEnvironment env)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _env = env;
        }

        [Route("Add-Book")]
        public async Task<ViewResult> AddBook(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "id", "name");
            return View();
        }
        [Route("Add-Book")]
        [HttpPost]
        public async Task<IActionResult> AddBook(BookVM book)
        {
            if (ModelState.IsValid)
            {
                if (book.bookCoverPhoto != null)
                {
                    string folder = "upload-photos/cover-book/";
                    book.bookCoverPhotoPathToDB = await UploadCoverOrGallryOrPdfForBook(folder, book.bookCoverPhoto);
                }

                if (book.bookGalleryPhotos != null)
                {
                    book.galleryVm = new List<GalleryVM>();
                    string folder = "upload-photos/galary-book/";
                    foreach (var photoGalary in book.bookGalleryPhotos)
                    {
                        book.galleryVm.Add(new GalleryVM
                        {
                            photoPath = await UploadCoverOrGallryOrPdfForBook(folder, photoGalary),
                            name = photoGalary.FileName
                        });
                    }
                }

                if (book.bookPDF != null)
                {
                    string folder = "upload-photos/pdf-book/";
                    book.bookPDFPathToDB = await UploadCoverOrGallryOrPdfForBook(folder, book.bookPDF);
                }

                int id = await _bookRepository.AddBook(book);
                if (id > 0) return RedirectToAction("AddBook", new { isSuccess = true, bookId = id });
            }
            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "id", "name");
            ModelState.AddModelError("", "Faild: check errors");
            return View(book);
        }

        private async Task<string> UploadCoverOrGallryOrPdfForBook(string folder, IFormFile file)
        {
            folder += Guid.NewGuid().ToString() + "_" + file.FileName;
            string serverFolder = Path.Combine(_env.WebRootPath, folder);
            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/" + folder;
        }

        //...Ajax,test jquery-ajax-unobtrusive library
        //..learn it , its complicated a little
        [HttpPost]
        public IActionResult AjaxAddBook(BookVM book)
        {
            return Json(true);
        }
        //.......................................//

        [Route("All-Book")]
        public async Task<ViewResult> GetBooks()
        {
            return View(await _bookRepository.GetBooks());
        }
        [Route("Book-Details/{id}")]
        public async Task<ViewResult> GetBookById(int id)
        {
            return View(await _bookRepository.GetBookById(id));
        }

        public List<BookVM> GetBookByTitleOrAuthor(string title, string author)
        {
            return _bookRepository.GetBookByTitleOrAuthor(title, author);
        }
    }
}
