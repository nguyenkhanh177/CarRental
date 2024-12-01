using CarRental.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            Function._ReturnLink = "/About";
            return RedirectToAction("Index", "Login");
        }
    }
}
