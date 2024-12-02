using CarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.ViewComponents
{
    public class TestimonialViewComponent : ViewComponent
    {
        public readonly CarRentalContext _context;

        public TestimonialViewComponent(CarRentalContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var item = _context.TbTestimonials.OrderByDescending(i=>i.Idtestimonial).ToList();
            return await Task.FromResult<IViewComponentResult>(View(item));
        }
    }
}
