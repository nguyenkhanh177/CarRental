using CarRental.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace CarRental.ViewComponents
{
    public class NotificalViewComponent : ViewComponent
    {
        private readonly CarRentalContext _context;

        public NotificalViewComponent(CarRentalContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notifical = _context.TbNotificalAdmins.OrderByDescending(i=>i.Time).Take(10).ToList();
            return await Task.FromResult<IViewComponentResult>(View(notifical));
        }
    }
}
