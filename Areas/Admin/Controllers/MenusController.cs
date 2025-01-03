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
    public class MenusController : Controller
    {
        private readonly CarRentalContext _context;

        public MenusController(CarRentalContext context)
        {
            _context = context;
        }

        // GET: Admin/Menus
        public async Task<IActionResult> Index()
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            ViewData["Menu"] = _context.TbMenus.ToList();
            return View(await _context.TbMenus.ToListAsync());
        }

        // GET: Admin/Menus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            if (id == null)
            {
                return NotFound();
            }

            var tbMenu = await _context.TbMenus
                .FirstOrDefaultAsync(m => m.Idmenu == id);
            if (tbMenu == null)
            {
                return NotFound();
            }

            return View(tbMenu);
        }

        // GET: Admin/Menus/Create
        public IActionResult Create()
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            ViewData["Menu"] = new SelectList(_context.TbMenus.Where(m => m.ParentMenu == 0), "Idmenu", "Title");
            return View();
        }

        // POST: Admin/Menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idmenu,Title,Alias,Position,ParentMenu,IsQuickLink")] TbMenu tbMenu)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            if (ModelState.IsValid)
            {
                _context.Add(tbMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Menu"] = new SelectList(_context.TbMenus.Where(m => m.ParentMenu == 0 ), "Idmenu", "Title", tbMenu.Idmenu);
            return View(tbMenu);
        }

        // GET: Admin/Menus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            if (id == null)
            {
                return NotFound();
            }

            var tbMenu = await _context.TbMenus.FindAsync(id);
            if (tbMenu == null)
            {
                return NotFound();
            }
            ViewData["Menu"] = new SelectList(_context.TbMenus.Where(m=>m.ParentMenu == 0 && m.Idmenu != id), "Idmenu", "Title");
            return View(tbMenu);
        }

        // POST: Admin/Menus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idmenu,Title,Alias,Position,ParentMenu,IsQuickLink")] TbMenu tbMenu)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            if (id != tbMenu.Idmenu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbMenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbMenuExists(tbMenu.Idmenu))
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
            ViewData["Menu"] = new SelectList(_context.TbMenus.Where(m => m.ParentMenu == 0 && m.Idmenu != id), "Idmenu", "Title", tbMenu.Idmenu);
            return View(tbMenu);
        }

        // GET: Admin/Menus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            if (id == null)
            {
                return NotFound();
            }

            var tbMenu = await _context.TbMenus
                .FirstOrDefaultAsync(m => m.Idmenu == id);
            if (tbMenu == null)
            {
                return NotFound();
            }

            return View(tbMenu);
        }

        // POST: Admin/Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            var tbMenu = await _context.TbMenus.FindAsync(id);
            if (tbMenu != null)
            {
                _context.TbMenus.Remove(tbMenu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbMenuExists(int id)
        {
            return _context.TbMenus.Any(e => e.Idmenu == id);
        }
    }
}
