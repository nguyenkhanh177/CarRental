using CarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Areas.Admin.Controllers
{
    public class BookingsController : Controller
    {
        private readonly CarRentalContext _context;

        public BookingsController(CarRentalContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Confirm(int Id)
        {
            var item = _context.TbBookings.FirstOrDefault(i=>i.Idbooking == Id);
            if (item == null) {
                return NotFound();
            }
            item.IsConfirm = true;
            _context.Update(item);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Refuse(int Id, string Message) { 

            var item = _context.TbBookings.FirstOrDefault(i=>i.Idbooking == Id);
            if (item == null) { 
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
