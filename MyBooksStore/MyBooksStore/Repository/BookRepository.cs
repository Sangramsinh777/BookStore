using Microsoft.EntityFrameworkCore;
using MyBooksStore.Data;
using MyBooksStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooksStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
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
                UpdatedOn = DateTime.UtcNow
            };

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
                books.Add(new BookModel() { 
                    Id=book.Id,
                    Title=book.Title,
                    Author=book.Author,
                    Description=book.Description,
                    TotalPages=book.TotalPages,
                    LanguageId = book.LanguageId,
                    Language=book.Language.Name,
                    Category=book.Category
                });
            }

            return books;

        }

        public async Task<BookModel> GetBookById(int id)
        {
            return await  _context.Books.Where(b=>b.Id==id).
                Select( book => new BookModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description,
                    TotalPages = book.TotalPages,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    Category = book.Category
                }).FirstOrDefaultAsync();
        }

       
        public List<BookModel> SearchBook(string title, string author)
        {
            return null;
        }

       
    }
}
