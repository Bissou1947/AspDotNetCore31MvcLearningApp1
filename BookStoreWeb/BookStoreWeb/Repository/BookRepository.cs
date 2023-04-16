using BookStoreWeb.Data;
using BookStoreWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreWeb.Repository
{
    public class BookRepository
    {
        private readonly BookStoreWebContext _db = null;
        public BookRepository(BookStoreWebContext db)
        {
            _db = db;
        }
        public async Task<int> AddBook(BookVM book)
        {
            var newBook = new Book()
            {
                title = book.title,
                author = book.author,
                description = book.description,
                page = book.page,
                creatDate = DateTime.UtcNow,
                updateDate = DateTime.UtcNow,
                category = book.category,
                languageId = book.languageId,
                coverPhotoPath = book.bookCoverPhotoPathToDB,
                pdfPath = book.bookPDFPathToDB
            };

            if (book.galleryVm.Any())
            {
                newBook.Gallery = new List<Gallery>();
                foreach (var file in book.galleryVm)
                {
                    newBook.Gallery.Add(new Gallery
                    {
                        photoPath = file.photoPath,
                        name = file.name,
                    });
                }
            }

            await _db.Books.AddAsync(newBook);
            await _db.SaveChangesAsync();

            return newBook.id;
        }
        public async Task<List<BookVM>> GetBooks()
        {
            return await _db.Books.Select(a => new BookVM
            {
                id = a.id,
                title = a.title,
                author = a.author,
                description = a.description,
                page = a.page,
                creatDate = a.creatDate,
                updateDate = a.updateDate,
                category = a.category,
                languageId = a.languageId,
                languageName = a.Language.name,
                bookCoverPhotoPathToDB = a.coverPhotoPath
            }).ToListAsync();
        }

        public async Task<List<BookVM>> GetTopBooks(int top)
        {
            return await _db.Books.Select(a => new BookVM
            {
                id = a.id,
                title = a.title,
                author = a.author,
                description = a.description,
                page = a.page,
                creatDate = a.creatDate,
                updateDate = a.updateDate,
                category = a.category,
                languageId = a.languageId,
                languageName = a.Language.name,
                bookCoverPhotoPathToDB = a.coverPhotoPath
            }).Take(top).ToListAsync();
        }

        public async Task<BookVM> GetBookById(int id)
        {
            return await _db.Books.Where(b => b.id == id).Select(a => new BookVM
            {
                id = a.id,
                title = a.title,
                author = a.author,
                description = a.description,
                page = a.page,
                creatDate = a.creatDate,
                updateDate = a.updateDate,
                category = a.category,
                languageId = a.languageId,
                languageName = a.Language.name,
                bookCoverPhotoPathToDB = a.coverPhotoPath,
                galleryVm = a.Gallery.Select(c => new GalleryVM()
                {
                    bookId = c.id,
                    name = c.name,
                    photoPath = c.photoPath,
                }).ToList(),
                bookPDFPathToDB = a.pdfPath,
            }).FirstOrDefaultAsync();
        }

        public List<BookVM> GetBookByTitleOrAuthor(string title, string author)
        {
            //return DB_Data().Where(a => a.title.ToLower().Contains(title.ToLower()) || a.author.ToLower().Contains(author.ToLower())).ToList();
            return null;
        }

    }
}
