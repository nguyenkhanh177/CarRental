using Microsoft.AspNetCore.Mvc;
using CarRental.Utilities;
namespace CarRental.Controllers
{
    public class OurTeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            Function._ReturnLink = "/OurTeam";
            return RedirectToAction("Index", "Login");
        }
    }
}
