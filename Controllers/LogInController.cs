using Microsoft.AspNetCore.Mvc;
using CarRental.Models;
namespace CarRental.Controllers
{
    public class LogInController : Controller
    {
        private readonly CarRentalContext _context;

        [HttpPost]
        public IActionResult LoginAction(string Username, string Password)
        {

            if (string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Username))
            {
                return View("Index","Vui lòng nhập đủ các trường");
            }
            else
            {
                
                if (_context == null || _context.TbCustomers == null)
                {
                    return View("Index", "Bạn nhập sai tài khoản hoặc mật khẩu");
                }
                foreach (var i in _context.TbCustomers.ToList())
                {
                    if (i.Username == Username && i.Password == Password)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                return View("Index", "Bạn nhập sai tài khoản hoặc mật khẩu");


            }

        }

        public IActionResult Index()
        {
            return View((Object)"");
        }
    }
}
