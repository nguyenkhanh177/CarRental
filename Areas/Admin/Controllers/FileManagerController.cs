using CarRental.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Areas.Admin.Controllers
{
    public class FileManagerController : Controller
    {
        [Area("Admin")]
        [Route("/Admin/file-manager")]
        public IActionResult Index()
        {
            if (Function.AdminIsLogin())
            {
                return View();
            }
            return RedirectToAction("Index", "Login");
        }

    }
}