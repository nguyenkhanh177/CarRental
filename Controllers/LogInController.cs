using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    public class LogInController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
