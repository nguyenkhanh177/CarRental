using System.Text.RegularExpressions;
using CarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    public class RegisterController : Controller
    {
        private readonly CarRentalContext _context;

        public RegisterController(CarRentalContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult RegisterAction(string Username, string Password, string RePassword, string Phone, string Email, string Name, int ID, DateOnly Birth, string Address)
        {

            if (string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(RePassword) || string.IsNullOrEmpty(Phone) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Name) || ID == null || string.IsNullOrEmpty(Address))
            {
                return View("Index", "Vui lòng nhập đủ các trường");
            }
            else
            {

                if (!IsValidUsername(Username))
                {
                    return View("Index", "Tên tài khoản chỉ chấp nhận chữ cái, chữ số và dấu gạch dưới");
                }
                else if (!IsValidPassword(Password))
                {
                    return View("Index", "Mật khẩu phải chứa một chữ cái, một số và độ dài tối thiểu là 8 ký tự");
                }
                else if(Password != RePassword)
                {
                    return View("Index", "Mật khẩu và mật khẩu nhập lại phải giống nhau");
                }
                foreach (var i in _context.TbCustomers.ToList())
                {
                    if (i.Username == Username)
                    {
                        return View("Index", "Tên tài khoản đã tồn tại");
                    }
                    else if (i.Idcard == ID)
                    {
                        return View("Index", "Căn cước công dân của bạn đã từng đăng ký");
                    }
                }
                var customer = new TbCustomer
                {
                    Username = Username,
                    Password = Password,
                    Phone = Phone,
                    Email = Email,
                    Name = Name,
                    Idcard = ID,
                    Address = Address,
                    Birth = Birth,
                    Avatar = "Avatar-1.jpg"
                };
                _context.TbCustomers.Add(customer);
                _context.SaveChanges();
                return View("Index","Đăng ký thành công, hãy đăng nhập");
            }
        }

        private bool IsValidUsername(string username)
        {
            string pattern = @"^[a-zA-Z0-9_]+$";
            return Regex.IsMatch(username, pattern);
        }

        private bool IsValidPassword(string password)
        {
            string pattern = @"^(?=.*[a-zA-Z])(?=.*\d).{8,}$";
            return Regex.IsMatch(password, pattern);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
