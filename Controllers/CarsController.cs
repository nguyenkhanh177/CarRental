using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    public class CarsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
