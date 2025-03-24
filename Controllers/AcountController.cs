using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Security.Cryptography.X509Certificates;

namespace LastTimeViewed.Controllers
{
    public class AcountController : Controller
    {
        public IActionResult Index()
        {
            string username = Request.Cookies["LastUser"];
            bool rememberMe;
            return View();
        }
        [HttpPost]
        public IActionResult SaveUser(string username, string rememberMe)
        {
            if (rememberMe != null)
            {
                Response.Cookies.Append("LastUser", username, new CookieOptions
                {
                    Expires = DateTime.UtcNow.AddYears(1),
                    HttpOnly = true,
                    IsEssential = true
                });
                ViewBag.Username = username;
            }
            return RedirectToAction("Index");
        }
    }
}
