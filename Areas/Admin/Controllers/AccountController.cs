using Microsoft.AspNetCore.Mvc;
using CarRental.Utilities;
using CarRental.Models;
using System.Runtime.CompilerServices;
namespace CarRental.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly CarRentalContext _context;

        public AccountController(CarRentalContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            var check = _context.TbAdmins.FirstOrDefault(i => i.Idadmin == Function._AdminId);
            if (check == null)
            {
                return NotFound();
            }
            return View(check);
        }
        [HttpPost]
        public IActionResult Index([Bind("Idadmin, Name, Avatar")] TbAdmin admin)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            var check = _context.TbAdmins.FirstOrDefault(i => i.Idadmin == Function._AdminId);
            check.Name = admin.Name;
            check.Avatar = admin.Avatar;
            _context.Update(check);
            _context.SaveChanges();
            Function._AdminName = check.Name;
            Function._AdminAvatar = check.Avatar;
            return View(check);
        }
        [HttpPost]
        public IActionResult Contact([Bind("Idadmin, Phone, Email")] TbAdmin admin)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            var check = _context.TbAdmins.FirstOrDefault(i => i.Idadmin == Function._AdminId);
            check.Phone = admin.Phone;
            check.Email = admin.Email;
            _context.Update(check);
            _context.SaveChanges();
            Function._AdminEmail = check.Email;
            Function._AdminPhone = check.Phone;
            return RedirectToAction("Index", check);
        }
        [HttpPost]
        public IActionResult RePassword(string password, string newpassword, string confirmpassword)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            var check = _context.TbAdmins.FirstOrDefault(i => i.Idadmin == Function._AdminId);
            if (check.Password != Function.MD5Password( password))
            {
                Function._Message = "Sai mật khẩu";
                return RedirectToAction("Index", check);
            }
            if (newpassword != confirmpassword)
            {
                Function._Message = "Mật khẩu mới và mật khẩu nhập lại phải giống nhau";
                return RedirectToAction("Index", check);
            }
            check.Password = Function.MD5Password(newpassword);
            _context.Update(check);
            _context.SaveChanges();
            Function._Message = string.Empty;
            Function._AdminEmail = check.Email;
            Function._AdminPhone = check.Phone;
            return RedirectToAction("Index", check);
        }
    }
}
