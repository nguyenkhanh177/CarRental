using Microsoft.AspNetCore.Mvc;
using CarRental.Utilities;
namespace CarRental.Controllers
{
    public class TestimonialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            Function._ReturnLink = "/Testimonial";
            return RedirectToAction("Index", "Login");
        }
    }
}
