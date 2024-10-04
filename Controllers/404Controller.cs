using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    public class _404Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
