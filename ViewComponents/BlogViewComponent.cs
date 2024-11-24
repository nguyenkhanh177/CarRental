using CarRental.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace CarRental.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        private readonly CarRentalContext _context;

        public BlogViewComponent(CarRentalContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbBlogs.Include(m=>m.TbBlogComments).Include(m=>m.IdadminNavigation).OrderByDescending(m=>m.PublishTime).ToList();
            return await Task.FromResult<IViewComponentResult>(View(items));
        }
    }
}
