using CarRental.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRental.Utilities;

namespace CarRental.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly CarRentalContext _context;

        public HomeController(CarRentalContext context)
        {
            
            _context = context;
        }
        public IActionResult Index()
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            ViewBag.Booking = _context.TbBookings.Include(i=>i.IdcustomerNavigation).Include(i=>i.IdcarNavigation).ThenInclude(i=>i.IdproductionModelNavigation).Where(i=>i.IsConfirm == null).OrderByDescending(i=>i.AppointmentTime).ToList();
            return View();
        }

        public IActionResult LogOut()
        {
            Function._AdminId = 0;
            Function._AdminName = string.Empty;
            Function._AdminPhone = string.Empty;
            Function._AdminEmail = string.Empty;
            Function._Message = string.Empty;
            Function._AdminUsername = string.Empty;

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Confirm(int Id)
        {
            var item = _context.TbBookings.FirstOrDefault(i => i.Idbooking == Id);
            if (item == null)
            {
                return NotFound();
            }
            item.IsConfirm = true;
            _context.Update(item);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Refuse(int Id, string Message)
        {

            var item = _context.TbBookings.FirstOrDefault(i => i.Idbooking == Id);
            if (item == null)
            {
                return NotFound();
            }

            item.IsConfirm = false;
            item.Reason = Message;
            _context.Update(item);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");

        }



    }
}
