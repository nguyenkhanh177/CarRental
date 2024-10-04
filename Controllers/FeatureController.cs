using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    public class FeatureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
