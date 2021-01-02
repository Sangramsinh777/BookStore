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
using MyBooksStore.Services;

namespace MyBooksStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NewBookConfig _configuration;
        private readonly NewBookConfig _thirdPartyConfig;
        private readonly IMessageRepository _messageRepository;
        private readonly IUserService _userService;
       
        public HomeController(ILogger<HomeController> logger , IOptionsSnapshot<NewBookConfig> newConfigOtions , IMessageRepository messageRepository,
            IUserService userService
            )
        {
            _logger = logger;
            _messageRepository = messageRepository;
            _configuration = newConfigOtions.Get("InternalBook");
            _thirdPartyConfig = newConfigOtions.Get("ThirdPartyBook");
            _userService = userService;
        }

        public ViewResult Index()
        {
            var id = _userService.GetUserId();
            var isLoggedIn = _userService.IsLoggedUser();

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
