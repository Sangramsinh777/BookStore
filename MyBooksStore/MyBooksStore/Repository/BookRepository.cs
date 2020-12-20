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
                Language=bookModel.Language,
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
                    Language=book.Language,
                    Category=book.Category
                });
            }

            return books;

        }

        public async Task<BookModel> GetBookById(int id)
        {
            var book = await  _context.Books.FindAsync(id);

            var bookDetails=new BookModel()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                TotalPages =book.TotalPages ,
                Language = book.Language,
                Category = book.Category
            };
            return bookDetails;
        }

        //public List<BookModel> GetAllBooks()
        //{
        //    return DataSource();
        //}

        //public BookModel GetBookById(int id)
        //{
        //    return DataSource().Where(b => b.Id == id).FirstOrDefault();
        //}

        public List<BookModel> SearchBook(string title, string author)
        {
            return DataSource().Where(b => b.Title.Contains(title) || b.Author.Contains(author)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>() {
                new BookModel(){Id=1 , Title="C" , Author="sangram" , Description="This is C Description.", Category="Programming" , Language="English" , TotalPages=100},
                new BookModel(){ Id=2 , Title="C++" , Author="ritesh" , Description="This is C++ Description.",Category="Programming" , Language="English" , TotalPages=120},
                new BookModel(){ Id=3 , Title="C#" , Author="happy" , Description="This is C# Description.",Category="Programming" , Language="English" , TotalPages=150},
                new BookModel(){ Id=4 , Title="Python" , Author="Pravin" , Description="This is Python Description.",Category="Programming" , Language="English" , TotalPages=200}
            };
        }
    }
}
