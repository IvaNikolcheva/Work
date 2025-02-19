using LastTimeViewed.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LastTimeViewed.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {   
            Response.Cookies.Append("LastLogIn", DateTime.Now.ToString(), new CookieOptions
            {
                Expires = DateTime.UtcNow.AddYears(1),
                HttpOnly = true,
                IsEssential = true
            });
            var logIn = Request.Cookies["LastLogIn"] ?? "";
            ViewBag.LogIn = logIn;
            return View();
        }
        [HttpPost]
        public IActionResult ShowLastLogIn(string logIn)
        {
            
            return RedirectToAction("Index");
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
