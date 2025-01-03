using CarRental.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRental.Utilities;

namespace CarRental.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly CarRentalContext _context;

        public LoginController(CarRentalContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(TbAdmin admin)
        {
            if (admin == null)
            {
                return RedirectToAction("Index", "LogIn");
            }
            string password = Function.MD5Password(admin.Password);
            var check = _context.TbAdmins.Where(m => ((m.Username == admin.Username) && (m.Password == password))).FirstOrDefault();
            if (check == null)
            {
                Function._Message = "Sai thông tin đăng nhập";
                return RedirectToAction("Index", "LogIn");
            }
            Function._AdminUsername = admin.Username;
            Function._AdminAvatar = check.Avatar;
            Function._Message = string.Empty;
            Function._AdminId = check.Idadmin;
            Function._AdminPhone = check.Phone;
            Function._AdminName = check.Name;
            Function._AdminEmail = check.Email;
            return RedirectToAction("Index", "Home");
        }
    }
}
