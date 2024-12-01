using Microsoft.AspNetCore.Mvc;
using CarRental.Utilities;

namespace CarRental.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            Function._ReturnLink = "/Contact";
            return RedirectToAction("Index", "Login");
        }
    }
}
