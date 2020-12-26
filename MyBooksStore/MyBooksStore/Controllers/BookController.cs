using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBooksStore.Models;
using MyBooksStore.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooksStore.Controllers
{
    public class BookController : Controller
    {
        BookRepository _bookRepository = null;
        LanguageRepository _languageRepository = null;
        IWebHostEnvironment _webHostEnvironment = null;
        public BookController(BookRepository bookRepository , LanguageRepository languageRepository , IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ViewResult> AddBook(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;

            ViewBag.Language=new SelectList(await _languageRepository.GetLanguages(),"Id","Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                if (bookModel.CoverPhoto != null)
                {
                    string folderPath = "image/cover/";
                    bookModel.CoverImageUrl= await UploadImage(folderPath,bookModel.CoverPhoto);

                }
                if (bookModel.GalleryFiles != null)
                {
                    string folder = "image/gallery/";
                    bookModel.Gallery = new List<GalleryModel>();

                    foreach (var file in bookModel.GalleryFiles)
                    {
                        var gallery = new GalleryModel() { 
                            Name=file.FileName,
                            Url= await UploadImage(folder, file)
                            };

                        bookModel.Gallery.Add(gallery);
                        
                    }
                }

                if (bookModel.BookPdf != null)
                {
                    string folderPath = "image/pdf/";
                    bookModel.BookPdfUrl = await UploadImage(folderPath,bookModel.BookPdf);
                }

                int id = await _bookRepository.AddBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddBook), new { isSuccess = true, bookId = id });
                }
            }
            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");
            return View();
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
           
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            
            string serverPath = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverPath, FileMode.Create));

            return "/" + folderPath;
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


        public List<BookModel> SearchBook(string title, string author)
        {
            return _bookRepository.SearchBook(title, author);
        }
    }
}
