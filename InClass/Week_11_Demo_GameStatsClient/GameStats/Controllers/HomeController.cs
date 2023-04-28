using GameStats.Models;
using GameStats.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace GameStats.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly ILogger<HomeController> _logger;
        private readonly WebServiceClient _client;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _client = new WebServiceClient();
        }

        public IActionResult Index()
        {

            var stats = _client.GetAllStats();

            return View(stats);
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