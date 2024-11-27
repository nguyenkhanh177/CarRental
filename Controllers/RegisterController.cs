using System.Text.RegularExpressions;
using CarRental.Models;
using CarRental.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;

namespace CarRental.Controllers
{
    public class RegisterController : Controller
    {
        private readonly CarRentalContext _context;

        public RegisterController(CarRentalContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(TbCustomer customer)
        {
            customer.Avatar = "/files/Avatars/AvatarDefault.jpg";
            if (customer == null)
            {
                return NotFound();
            }

            var checkUsername = _context.TbCustomers.Where(m => m.Username == customer.Username).FirstOrDefault();
            var checkPhone = _context.TbCustomers.Where(m => m.Phone == customer.Phone).FirstOrDefault();
            var checkIDCard = _context.TbCustomers.Where(m => m.Idcard == customer.Idcard).FirstOrDefault();
            if (checkUsername != null)
            {
                Function._Message = "Tên người dùng đã tồn tại";
                return RedirectToAction("Index", "Register");
            }
            else if (checkPhone != null)
            {
                Function._Message = "Số điện thoại đã tồn tại";
                return RedirectToAction("Index", "Register");
            }
            else if (checkIDCard != null)
            {
                Function._Message = "Số căn cước công dân đã tồn tại";
                return RedirectToAction("Index", "Register");
            }
            Function._Message = string.Empty;
            customer.Password = Function.MD5Password(customer.Password);
            _context.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "LogIn");

        }
    }
}
