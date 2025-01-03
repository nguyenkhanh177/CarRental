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
    public class ProductionModelsController : Controller
    {
        private readonly CarRentalContext _context;

        public ProductionModelsController(CarRentalContext context)
        {
            _context = context;
        }

        // GET: Admin/ProductionModels
        public async Task<IActionResult> Index()
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            var carRentalContext = _context.TbProductionModels.Include(t => t.IdautomakerNavigation).Include(t => t.IddriverCapabilitiesNavigation).Include(t => t.IdfuelNavigation).Include(t => t.IdgearboxNavigation);
            return View(await carRentalContext.ToListAsync());
        }

        // GET: Admin/ProductionModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            if (id == null)
            {
                return NotFound();
            }

            var tbProductionModel = await _context.TbProductionModels
                .Include(t => t.IdautomakerNavigation)
                .Include(t => t.IddriverCapabilitiesNavigation)
                .Include(t => t.IdfuelNavigation)
                .Include(t => t.IdgearboxNavigation)
                .FirstOrDefaultAsync(m => m.IdproductionModel == id);
            if (tbProductionModel == null)
            {
                return NotFound();
            }

            return View(tbProductionModel);
        }

        // GET: Admin/ProductionModels/Create
        public IActionResult Create()
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            ViewData["Idautomaker"] = new SelectList(_context.TbAutomakers, "Idautomaker", "AutomakerName");
            ViewData["IddriverCapabilities"] = new SelectList(_context.TbDriverCapabilities, "IddriverCapabilities", "DriverCapabilitiesName");
            ViewData["Idfuel"] = new SelectList(_context.TbFuels, "Idfuel", "FuelName");
            ViewData["Idgearbox"] = new SelectList(_context.TbGearboxes, "Idgearbox", "GearboxName");
            return View();
        }

        // POST: Admin/ProductionModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdproductionModel,Idautomaker,SeatingCapacity,Idgearbox,Idfuel,Describe,Star,IddriverCapabilities,ProductionModelName")] TbProductionModel tbProductionModel)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            if (ModelState.IsValid)
            {
                _context.Add(tbProductionModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idautomaker"] = new SelectList(_context.TbAutomakers, "Idautomaker", "AutomakerName", tbProductionModel.Idautomaker);
            ViewData["IddriverCapabilities"] = new SelectList(_context.TbDriverCapabilities, "IddriverCapabilities", "DriverCapabilitiesName", tbProductionModel.IddriverCapabilities);
            ViewData["Idfuel"] = new SelectList(_context.TbFuels, "Idfuel", "FuelName", tbProductionModel.Idfuel);
            ViewData["Idgearbox"] = new SelectList(_context.TbGearboxes, "Idgearbox", "GearboxName", tbProductionModel.Idgearbox);
            return View(tbProductionModel);
        }

        // GET: Admin/ProductionModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            if (id == null)
            {
                return NotFound();
            }

            var tbProductionModel = await _context.TbProductionModels.FindAsync(id);
            if (tbProductionModel == null)
            {
                return NotFound();
            }
            ViewData["Idautomaker"] = new SelectList(_context.TbAutomakers, "Idautomaker", "AutomakerName", tbProductionModel.Idautomaker);
            ViewData["IddriverCapabilities"] = new SelectList(_context.TbDriverCapabilities, "IddriverCapabilities", "DriverCapabilitiesName", tbProductionModel.IddriverCapabilities);
            ViewData["Idfuel"] = new SelectList(_context.TbFuels, "Idfuel", "FuelName", tbProductionModel.Idfuel);
            ViewData["Idgearbox"] = new SelectList(_context.TbGearboxes, "Idgearbox", "GearboxName", tbProductionModel.Idgearbox);
            return View(tbProductionModel);
        }

        // POST: Admin/ProductionModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdproductionModel,Idautomaker,SeatingCapacity,Idgearbox,Idfuel,Describe,Star,IddriverCapabilities,ProductionModelName")] TbProductionModel tbProductionModel)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            if (id != tbProductionModel.IdproductionModel)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbProductionModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbProductionModelExists(tbProductionModel.IdproductionModel))
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
            ViewData["Idautomaker"] = new SelectList(_context.TbAutomakers, "Idautomaker", "AutomakerName", tbProductionModel.Idautomaker);
            ViewData["IddriverCapabilities"] = new SelectList(_context.TbDriverCapabilities, "IddriverCapabilities", "DriverCapabilitiesName", tbProductionModel.IddriverCapabilities);
            ViewData["Idfuel"] = new SelectList(_context.TbFuels, "Idfuel", "FuelName", tbProductionModel.Idfuel);
            ViewData["Idgearbox"] = new SelectList(_context.TbGearboxes, "Idgearbox", "GearboxName", tbProductionModel.Idgearbox);
            return View(tbProductionModel);
        }

        // GET: Admin/ProductionModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            if (id == null)
            {
                return NotFound();
            }

            var tbProductionModel = await _context.TbProductionModels
                .Include(t => t.IdautomakerNavigation)
                .Include(t => t.IddriverCapabilitiesNavigation)
                .Include(t => t.IdfuelNavigation)
                .Include(t => t.IdgearboxNavigation)
                .FirstOrDefaultAsync(m => m.IdproductionModel == id);
            if (tbProductionModel == null)
            {
                return NotFound();
            }

            return View(tbProductionModel);
        }

        // POST: Admin/ProductionModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            var tbProductionModel = await _context.TbProductionModels.FindAsync(id);
            if (tbProductionModel != null)
            {
                _context.TbProductionModels.Remove(tbProductionModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbProductionModelExists(int id)
        {
            return _context.TbProductionModels.Any(e => e.IdproductionModel == id);
        }
    }
}
