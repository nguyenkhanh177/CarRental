using CarRental.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace CarRental.ViewComponents
{
    public class CarViewComponent : ViewComponent
    {
        private readonly CarRentalContext _context;

        public CarViewComponent(CarRentalContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbCars.Include(m => m.IdproductionModelNavigation).Include(m=>m.IdproductionModelNavigation.IdfuelNavigation).Include(m=>m.IdproductionModelNavigation.IdautomakerNavigation).Include(m=>m.IdproductionModelNavigation.IdgearboxNavigation).Include(m=>m.IdproductionModelNavigation.IddriverCapabilitiesNavigation).OrderByDescending(m => m.IdproductionModel).ToList();
            return await Task.FromResult<IViewComponentResult>(View(items));
        }
    }
}
