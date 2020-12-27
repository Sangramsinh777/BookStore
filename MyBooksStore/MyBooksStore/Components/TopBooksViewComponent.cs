using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MyBooksStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooksStore.Components
{
    public class TopBooksViewComponent : ViewComponent
    {
        private readonly IBookRepository _bookRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;
        public TopBooksViewComponent(IBookRepository bookRepository , IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var topBooks =await _bookRepository.GetTopBooksAsync(count);
            return View(topBooks);
        }

       
    }
}
