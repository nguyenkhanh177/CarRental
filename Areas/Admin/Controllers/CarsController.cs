using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRental.Models;
using CarRental.Utilities;

namespace CarRental.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarsController : Controller
    {
        private readonly CarRentalContext _context;

        public CarsController(CarRentalContext context)
        {
            _context = context;
        }

        // GET: Admin/Cars
        public async Task<IActionResult> Index()
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");

            var carRentalContext = _context.TbCars.Include(t => t.IdproductionModelNavigation);
            return View(await carRentalContext.ToListAsync());
        }

        // GET: Admin/Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");

            if (id == null)
            {
                return NotFound();
            }

            var tbCar = await _context.TbCars
                .Include(t => t.IdproductionModelNavigation)
                .FirstOrDefaultAsync(m => m.Idcar == id);
            if (tbCar == null)
            {
                return NotFound();
            }

            return View(tbCar);
        }

        // GET: Admin/Cars/Create
        public IActionResult Create()
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");

            ViewData["IdproductionModel"] = new SelectList(_context.TbProductionModels, "IdproductionModel", "ProductionModelName");
            return View();
        }

        // POST: Admin/Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idcar,IdproductionModel,Color,Image,Price")] TbCar tbCar)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");

            if (ModelState.IsValid)
            {
                _context.Add(tbCar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdproductionModel"] = new SelectList(_context.TbProductionModels, "IdproductionModel", "ProductionModelName", tbCar.IdproductionModel);
            return View(tbCar);
        }

        // GET: Admin/Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");

            if (id == null)
            {
                return NotFound();
            }

            var tbCar = await _context.TbCars.FindAsync(id);
            if (tbCar == null)
            {
                return NotFound();
            }
            ViewData["IdproductionModel"] = new SelectList(_context.TbProductionModels, "IdproductionModel", "ProductionModelName", tbCar.IdproductionModel);
            return View(tbCar);
        }

        // POST: Admin/Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idcar,IdproductionModel,Color,Image,Price")] TbCar tbCar)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");

            if (id != tbCar.Idcar)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbCarExists(tbCar.Idcar))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdproductionModel"] = new SelectList(_context.TbProductionModels, "IdproductionModel", "ProductionModelName", tbCar.IdproductionModel);
            return View(tbCar);
        }

        // GET: Admin/Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");

            if (id == null)
            {
                return NotFound();
            }

            var tbCar = await _context.TbCars
                .Include(t => t.IdproductionModelNavigation)
                .FirstOrDefaultAsync(m => m.Idcar == id);
            if (tbCar == null)
            {
                return NotFound();
            }

            return View(tbCar);
        }

        // POST: Admin/Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");

            var tbCar = await _context.TbCars.FindAsync(id);
            if (tbCar != null)
            {
                _context.TbCars.Remove(tbCar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbCarExists(int id)
        {

            return _context.TbCars.Any(e => e.Idcar == id);
        }
    }
}
