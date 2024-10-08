using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
