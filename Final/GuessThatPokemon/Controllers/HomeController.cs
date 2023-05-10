using GuessThatPokemon.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GuessThatPokemon.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.IsLoggedIn = IsLoggedIn;
            return View();
        }

        public IActionResult Credits()
        {
            ViewBag.IsLoggedIn = IsLoggedIn;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}