using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
