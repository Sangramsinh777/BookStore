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
            //return View("TempView/test.cshtml");
            //return View("~/TempView/test.cshtml");
            //return View("../../TempView/test");
            //ViewBag.Title = 123;
            //ViewBag.data = new { Id=1,Name="Sangram"};
            dynamic data = new ExpandoObject();
            data.Id = 1;
            data.Name = "Sangram";
            ViewBag.data = data;
            ViewBag.Type = new BookModel() { Id=2,Author="New Authoe"};

            ViewData["MyName"] = "Sangram Bhatesariyas";
            ViewData["Book"] = new BookModel() { Id=101 , Author="This is ViewData Author"};

            MyProperty = "ViewData Attribute Property";
            Title = "Custom Title";




            return View();
        }
        //public ViewResult Index()
        //{
        //    return View("AboutUs");
        //}

        //public string Index()
        //{
        //    return "BooksStore!";
        //}
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Privacy()
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
