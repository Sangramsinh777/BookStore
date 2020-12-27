using MyBooksStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBooksStore.Repository
{
    public interface IBookRepository
    {
        Task<int> AddBook(BookModel bookModel);
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBookById(int id);
        Task<List<BookModel>> GetTopBooksAsync(int count);
        List<BookModel> SearchBook(string title, string author);
        string GetApplicationName();
    }
}