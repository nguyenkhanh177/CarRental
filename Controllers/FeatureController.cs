using Microsoft.AspNetCore.Mvc;
using CarRental.Utilities;
namespace CarRental.Controllers
{
    public class FeatureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            Function._ReturnLink = "/Feature";
            return RedirectToAction("Index", "Login");
        }
    }
}
