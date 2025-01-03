using CarRental.Areas.Admin.Controllers;
using CarRental.Models;
using CarRental.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CarRental.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CarRentalContext _context;

        public HomeController(ILogger<HomeController> logger, CarRentalContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["ProductionModel"] = new SelectList(_context.TbProductionModels, "IdproductionModel", "ProductionModelName");
            ViewData["Branch"] = new SelectList(_context.TbBranches, "Idbranch", "NameBranch");
            return View();
        }

        [HttpGet]
        public IActionResult GetCarColors(int modelId)
        {
            var colors = _context.TbCars.Where(c => c.IdproductionModel == modelId).Select(c => c.Color).Distinct().ToList();
            return Json(colors);
        }

        [HttpPost]
        public async Task<IActionResult> Index([Bind("Idbooking, Idcustomer, AppointmentTime, Idcar, IsConfirm, Idbranch")] TbBooking booking, string pickUpDate, string pickUpTime, int IdproductionModel, string Color)
        {
            // Kết hợp giá trị ngày và giờ từ form để tạo ra DateTime
            booking.AppointmentTime = DateTime.Parse($"{pickUpDate} {pickUpTime}");
             var checkcar =  _context.TbCars.Where(i => (i.IdproductionModel == IdproductionModel) && (i.Color == Color)).FirstOrDefault();
            if(checkcar != null)
            {
                booking.Idcar = checkcar.Idcar;
            }
            booking.BookingTime = DateTime.Now;
            booking.Idcustomer = Function._IdCustomer;
            var checkbooking = _context.TbBookings.FirstOrDefault(i=>(i.Idcustomer ==  booking.Idcustomer)&&(i.IsConfirm == null));
            if (checkbooking != null) {
                Function._Message = "Bạn đang có một đơn chưa được duyệt";
                return View();
            }
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                Function._Message = string.Empty;
                TbNotificalAdmin tbNotificalAdmin = new TbNotificalAdmin();
                tbNotificalAdmin.Time = DateTime.Now;
                tbNotificalAdmin.Detail = $"{Function._Name} có id {Function._IdCustomer} đã đặt một đơn.";

                _context.Add(tbNotificalAdmin);
                await _context.SaveChangesAsync();
                return View();

            }
            ViewData["Branch"] = new SelectList(_context.TbBranches, "Idbranch", "NameBranch", booking.Idbranch);
            ViewData["ProductionModel"] = new SelectList(_context.TbProductionModels, "IdproductionModel", "ProductionModelName", checkcar.IdproductionModel);
            return View(booking);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Car(int IdproductionModel, string Color)
        {
            ViewData["ProductionModel"] = new SelectList(_context.TbProductionModels, "IdproductionModel", "ProductionModelName", IdproductionModel);
            ViewData["Branch"] = new SelectList(_context.TbBranches, "Idbranch", "NameBranch");
            ViewBag.Color = Color;

            return View("Index");
        }



        public IActionResult Login()
        {
            Function._ReturnLink = "/Home";
            Function._Message = string.Empty;
            return RedirectToAction("Index", "Login");
        }
        public IActionResult LogOut()
        {
            Function._IdCustomer = 0;
            Function._IdCard = string.Empty;
            Function._Phone = string.Empty;
            Function._Username = string.Empty;
            Function._Message = string.Empty;
            Function._Name = string.Empty;

            return RedirectToAction("Index", "Home");
        }
    }
}
