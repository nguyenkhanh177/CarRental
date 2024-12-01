using Microsoft.AspNetCore.Mvc;
using CarRental.Models;
using CarRental.Utilities;
namespace CarRental.Controllers
{
    public class LogInController : Controller
    {
        private readonly CarRentalContext _context;

        public LogInController(CarRentalContext context)
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
            if (customer == null)
            {
                return RedirectToAction("Index", "LogIn");
            }
            string password = Function.MD5Password(customer.Password);
            var check = _context.TbCustomers.Where(m => ((m.Username == customer.Username) && (m.Password == password))).FirstOrDefault();
            if (check == null)
            {
                Function._Message = "Sai thông tin đăng nhập";
                return RedirectToAction("Index", "LogIn");
            }
            Function._Username = customer.Username;
            Function._Message = string.Empty;
            Function._IdCustomer = check.Idcustomer;
            Function._IdCard = check.Idcard;
            Function._Phone = check.Phone;
            Function._Message = string.Empty;
            Function._Name = check.Name;
            if(string.IsNullOrEmpty(Function._ReturnLink))
            { return RedirectToAction("Index", "Home"); }
            else
            {
                return Redirect(Function._ReturnLink);  
            }
        }


    }
}
