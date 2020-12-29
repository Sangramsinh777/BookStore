using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBooksStore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MyBooksStore.Repository;

namespace MyBooksStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NewBookConfig _configuration;
        private readonly NewBookConfig _thirdPartyConfig;
        private readonly IMessageRepository _messageRepository;
       
        public HomeController(ILogger<HomeController> logger , IOptionsSnapshot<NewBookConfig> newConfigOtions , IMessageRepository messageRepository)
        {
            _logger = logger;
            //_configuration = newConfigOtions.Value;
            _messageRepository = messageRepository;
            _configuration = newConfigOtions.Get("InternalBook");
            _thirdPartyConfig = newConfigOtions.Get("ThirdPartyBook");
        }

        public ViewResult Index()
        {
            //var appName = _configuration["AppName"];
            //var key1 = _configuration["InfoObj:Key1"];
            //var key2 = _configuration["InfoObj:Key2"];
            //var key3 = _configuration["InfoObj:Key3:Key1AndKey2"];
            //var key4 = _configuration.GetValue<bool>("NewBookAlert");

            //var newBook = new NewBookConfig();
            //_configuration.Bind("NewBookAlertObj", newBook);
            bool isAlert = _configuration.DisplayNewBookAlert;
            var thirdParty = _thirdPartyConfig;

            var name = _messageRepository.GetName();

            return View();
        }
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
