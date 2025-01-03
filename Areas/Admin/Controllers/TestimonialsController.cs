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
    public class TestimonialsController : Controller
    {
        private readonly CarRentalContext _context;

        public TestimonialsController(CarRentalContext context)
        {
            _context = context;
        }

        // GET: Admin/Testimonials
        public async Task<IActionResult> Index()
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            return View(await _context.TbTestimonials.ToListAsync());
        }

        // GET: Admin/Testimonials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            if (id == null)
            {
                return NotFound();
            }

            var tbTestimonial = await _context.TbTestimonials
                .FirstOrDefaultAsync(m => m.Idtestimonial == id);
            if (tbTestimonial == null)
            {
                return NotFound();
            }

            return View(tbTestimonial);
        }

        // GET: Admin/Testimonials/Create
        public IActionResult Create()
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            return View();
        }

        // POST: Admin/Testimonials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idtestimonial,Name,Profession,Detail,Star,Image")] TbTestimonial tbTestimonial)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            if (ModelState.IsValid)
            {
                _context.Add(tbTestimonial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbTestimonial);
        }

        // GET: Admin/Testimonials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            if (id == null)
            {
                return NotFound();
            }

            var tbTestimonial = await _context.TbTestimonials.FindAsync(id);
            if (tbTestimonial == null)
            {
                return NotFound();
            }
            return View(tbTestimonial);
        }

        // POST: Admin/Testimonials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idtestimonial,Name,Profession,Detail,Star,Image")] TbTestimonial tbTestimonial)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            if (id != tbTestimonial.Idtestimonial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbTestimonial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbTestimonialExists(tbTestimonial.Idtestimonial))
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
            return View(tbTestimonial);
        }

        // GET: Admin/Testimonials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            if (id == null)
            {
                return NotFound();
            }

            var tbTestimonial = await _context.TbTestimonials
                .FirstOrDefaultAsync(m => m.Idtestimonial == id);
            if (tbTestimonial == null)
            {
                return NotFound();
            }

            return View(tbTestimonial);
        }

        // POST: Admin/Testimonials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            var tbTestimonial = await _context.TbTestimonials.FindAsync(id);
            if (tbTestimonial != null)
            {
                _context.TbTestimonials.Remove(tbTestimonial);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbTestimonialExists(int id)
        {
            return _context.TbTestimonials.Any(e => e.Idtestimonial == id);
        }
    }
}
