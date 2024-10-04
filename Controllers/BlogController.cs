using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
