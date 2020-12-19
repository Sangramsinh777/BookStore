using Microsoft.AspNetCore.Mvc;
using MyBooksStore.Models;
using MyBooksStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooksStore.Controllers
{
    public class BookController : Controller
    {
        BookRepository _bookRepository = null;
        public BookController()
        {
            _bookRepository = new BookRepository();
        }

        public ViewResult GetAllBooks()
        {
            var data = _bookRepository.GetAllBooks();
            return View(data);
        }

        public ViewResult GetBook(int id)
        {
            var data= _bookRepository.GetBookById(id);
            return View(data);
        }

        public ViewResult ContactUs()
        {
            return View();
        }

        //public List<BookModel> GetAllBooks()
        //{
        //    return _bookRepository.GetAllBooks();
        //}

        //public BookModel GetBook(int id)
        //{
        //    return _bookRepository.GetBookById(id);
        //}

        public List<BookModel> SearchBook(string title, string author)
        {
            return _bookRepository.SearchBook(title, author);
        }
    }
}
