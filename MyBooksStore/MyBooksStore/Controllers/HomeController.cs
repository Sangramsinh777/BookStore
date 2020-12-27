using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBooksStore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;

namespace MyBooksStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        [ViewData]
        public string MyProperty { get; set; }
        [ViewData]
        public string Title { get; set; }

       
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ViewResult Index()
        {
            return View();
        }
        //[Route("Privacy/{id}/{name}")]
        [Route("Privacy/{name:alpha:minlength(5)}")]
        public IActionResult Privacy(string name)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
