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
    public class CustomersController : Controller
    {
        private readonly CarRentalContext _context;

        public CustomersController(CarRentalContext context)
        {
            _context = context;
        }

        // GET: Admin/Customers
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbCustomers.ToListAsync());
        }

        // GET: Admin/Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCustomer = await _context.TbCustomers
                .FirstOrDefaultAsync(m => m.Idcustomer == id);
            if (tbCustomer == null)
            {
                return NotFound();
            }

            return View(tbCustomer);
        }

        // GET: Admin/Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idcustomer,Idcard,Name,Phone,Email,Address,Birth,Username,Password,Avatar")] TbCustomer tbCustomer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbCustomer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbCustomer);
        }

        // GET: Admin/Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCustomer = await _context.TbCustomers.FindAsync(id);
            if (tbCustomer == null)
            {
                return NotFound();
            }
            return View(tbCustomer);
        }

        // POST: Admin/Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idcustomer,Idcard,Name,Phone,Email,Address,Birth,Username,Password,Avatar")] TbCustomer tbCustomer)
        {
            if (id != tbCustomer.Idcustomer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCustomer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbCustomerExists(tbCustomer.Idcustomer))
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
            return View(tbCustomer);
        }

        // GET: Admin/Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCustomer = await _context.TbCustomers
                .FirstOrDefaultAsync(m => m.Idcustomer == id);
            if (tbCustomer == null)
            {
                return NotFound();
            }

            return View(tbCustomer);
        }

        // POST: Admin/Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbCustomer = await _context.TbCustomers.FindAsync(id);
            if (tbCustomer != null)
            {
                _context.TbCustomers.Remove(tbCustomer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbCustomerExists(int id)
        {
            return _context.TbCustomers.Any(e => e.Idcustomer == id);
        }
    }
}
