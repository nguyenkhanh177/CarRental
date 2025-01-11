using CarRental.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRental.Utilities;
namespace CarRental.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewAdminController : Controller
    {

        private readonly CarRentalContext _context;

        public NewAdminController(CarRentalContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (!Function.AdminIsLogin())
                return RedirectToAction("Index", "Login");
            return View();
        }

        [HttpPost]
        public IActionResult Index( TbAdmin tbAdmin)
        {
            var check = _context.TbAdmins.FirstOrDefault(i => i.Username == tbAdmin.Username);
            if (check != null)
            {
                Function._Message = "Tên tài khoản tồn tại";
                    return View();
            }
            tbAdmin.Password = Function.MD5Password(tbAdmin.Password);
            tbAdmin.Avatar = "/files/avatars/AvatarDefault.jpg";
            Function._Message = string.Empty;
            _context.Add(tbAdmin);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
