using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyBooksStore.Data;
using MyBooksStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooksStore.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context = null;
        private readonly IConfiguration _configuration=null;
        public BookRepository(BookStoreContext context , IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<int> AddBook(BookModel bookModel)
        {
            var newBook = new Books()
            {
                Title = bookModel.Title,
                Author = bookModel.Author,
                Description = bookModel.Description,
                TotalPages = bookModel.TotalPages,
                LanguageId = bookModel.LanguageId,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                CoverImageUrl = bookModel.CoverImageUrl,
                BookPdfUrl = bookModel.BookPdfUrl
            };
            newBook.bookGallery = new List<BookGallery>();
            foreach (var file in bookModel.Gallery)
            {
                newBook.bookGallery.Add(new BookGallery()
                {
                    Name = file.Name,
                    Url = file.Url
                });
            }

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allBooks = await _context.Books.ToListAsync();

            foreach (var book in allBooks)
            {
                books.Add(new BookModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description,
                    TotalPages = book.TotalPages,
                    LanguageId = book.LanguageId,
                    //Language=book.Language.Name,
                    Category = book.Category,
                    CoverImageUrl = book.CoverImageUrl
                });
            }

            return books;

        }
        public async Task<List<BookModel>> GetTopBooksAsync(int count)
        {
            return await _context.Books.Select(book => new BookModel()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                TotalPages = book.TotalPages,
                LanguageId = book.LanguageId,
                Category = book.Category,
                CoverImageUrl = book.CoverImageUrl
            }).Take(count).ToListAsync();

        }


        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.Books.Where(b => b.Id == id).
                Select(book => new BookModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description,
                    TotalPages = book.TotalPages,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    Category = book.Category,
                    Gallery = book.bookGallery.Select(g => new GalleryModel()
                    {
                        Id = g.Id,
                        Name = g.Name,
                        Url = g.Url
                    }).ToList(),
                    BookPdfUrl = book.BookPdfUrl
                }).FirstOrDefaultAsync();
        }


        public List<BookModel> SearchBook(string title, string author)
        {
            return null;
        }

        public string GetApplicationName()
        {
            return _configuration["AppName"]; 
        }
    }
}
