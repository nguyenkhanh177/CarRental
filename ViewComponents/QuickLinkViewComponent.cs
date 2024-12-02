using CarRental.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRental.Models;

namespace CarRental.ViewComponents
{
    public class QuickLinkViewComponent : ViewComponent
            {
        private readonly CarRentalContext _context;

        public QuickLinkViewComponent(CarRentalContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbMenus.Where(i=>i.IsQuickLink).ToList();
            return await Task.FromResult<IViewComponentResult>(View(items));
        }
    }
}
