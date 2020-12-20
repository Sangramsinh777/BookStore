using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public ViewResult AddBook(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;

            //var data = new BookModel() {Language="English" };
            ViewBag.Language = new SelectList(GetLanguage(), "Id", "Text");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddBook), new { isSuccess = true, bookId = id });
                }
            }
            
            ViewBag.Language = new SelectList(GetLanguage(), "Id", "Text");
            return View();
        }
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }

        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }

        private List<LanguageModel> GetLanguage()
        {
            return new List<LanguageModel>() { 
                new LanguageModel(){ Id=1,Text="English"},
                new LanguageModel(){ Id=2,Text="Hindi"},
                new LanguageModel() { Id=3 , Text="Gujarati"}
            };
        }

        //[HttpPost]
        //public ViewResult AddNewBook(BookModel bookModel)
        //{
        //    return View("AddBook");
        //}



        //[Route("book-detail/{id?}", Name ="BookById")]
        //public ViewResult GetBook(int id)
        //{
        //    var data= _bookRepository.GetBookById(id);
        //    return View(data);
        //}

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
