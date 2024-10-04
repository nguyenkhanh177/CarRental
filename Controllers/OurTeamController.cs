using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    public class OurTeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
