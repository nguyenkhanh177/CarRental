using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRental.Models;

namespace CarRental.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminsController : Controller
    {
        private readonly CarRentalContext _context;

        public AdminsController(CarRentalContext context)
        {
            _context = context;
        }

        // GET: Admin/Admins
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbAdmins.ToListAsync());
        }

        // GET: Admin/Admins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbAdmin = await _context.TbAdmins
                .FirstOrDefaultAsync(m => m.Idadmin == id);
            if (tbAdmin == null)
            {
                return NotFound();
            }

            return View(tbAdmin);
        }

        // GET: Admin/Admins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idadmin,Name,Username,Password,Phone,Email,Birth,Avatar")] TbAdmin tbAdmin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbAdmin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbAdmin);
        }

        // GET: Admin/Admins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbAdmin = await _context.TbAdmins.FindAsync(id);
            if (tbAdmin == null)
            {
                return NotFound();
            }
            return View(tbAdmin);
        }

        // POST: Admin/Admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idadmin,Name,Username,Password,Phone,Email,Birth,Avatar")] TbAdmin tbAdmin)
        {
            if (id != tbAdmin.Idadmin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbAdmin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbAdminExists(tbAdmin.Idadmin))
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
            return View(tbAdmin);
        }

        // GET: Admin/Admins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbAdmin = await _context.TbAdmins
                .FirstOrDefaultAsync(m => m.Idadmin == id);
            if (tbAdmin == null)
            {
                return NotFound();
            }

            return View(tbAdmin);
        }

        // POST: Admin/Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbAdmin = await _context.TbAdmins.FindAsync(id);
            if (tbAdmin != null)
            {
                _context.TbAdmins.Remove(tbAdmin);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbAdminExists(int id)
        {
            return _context.TbAdmins.Any(e => e.Idadmin == id);
        }
    }
}
