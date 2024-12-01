using Microsoft.AspNetCore.Mvc;
using CarRental.Utilities;
namespace CarRental.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            Function._ReturnLink = "/Service";
            return RedirectToAction("Index", "Login");
        }
    }

}
