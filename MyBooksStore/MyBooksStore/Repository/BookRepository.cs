using MyBooksStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooksStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(b => b.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string title , string author)
        {
            return DataSource().Where(b => b.Title.Contains(title) || b.Author.Contains(author)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>() { 
                new BookModel(){Id=1 , Title="C" , Author="sangram"},
                new BookModel(){ Id=2 , Title="C++" , Author="ritesh"},
                new BookModel(){ Id=3 , Title="C#" , Author="happy"}
            };
        }
    }
}
