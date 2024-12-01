using CarRental.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    public class CarsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            Function._ReturnLink = "/Cars";
            return RedirectToAction("Index", "Login");
        }
    }
}
