using CarRental.Areas.Admin.Controllers;
using CarRental.Models;
using CarRental.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CarRental.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult LogOut()
        {
            Function._IdCustomer = 0;
            Function._IdCard = string.Empty;
            Function._Phone = string.Empty;
            Function._Password = string.Empty;
            Function._Username = string.Empty;
            Function._Message = string.Empty;
            Function._Name = string.Empty;

            return RedirectToAction("Index", "Home");
        }
    }
}
