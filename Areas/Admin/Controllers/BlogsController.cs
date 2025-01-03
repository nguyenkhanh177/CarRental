﻿using System;
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
    public class BlogsController : Controller
    {
        private readonly CarRentalContext _context;

        public BlogsController(CarRentalContext context)
        {
            _context = context;
        }

        // GET: Admin/Blogs
        public async Task<IActionResult> Index()
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");

            var carRentalContext = _context.TbBlogs.Include(t => t.IdadminNavigation);
            return View(await carRentalContext.ToListAsync());
        }

        // GET: Admin/Blogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");

            if (id == null)
            {
                return NotFound();
            }

            var tbBlog = await _context.TbBlogs
                .Include(t => t.IdadminNavigation)
                .FirstOrDefaultAsync(m => m.Idblog == id);
            if (tbBlog == null)
            {
                return NotFound();
            }

            return View(tbBlog);
        }

        // GET: Admin/Blogs/Create
        public IActionResult Create()
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");

            ViewData["Idadmin"] = new SelectList(_context.TbAdmins, "Idadmin", "Name");
            return View();
        }

        // POST: Admin/Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Idblog,Detail,PublishTime,Description,Image,Idadmin")] TbBlog tbBlog)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            tbBlog.PublishTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(tbBlog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idadmin"] = new SelectList(_context.TbAdmins, "Idadmin", "Name", tbBlog.Idadmin);
            return View(tbBlog);
        }

        // GET: Admin/Blogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            if (id == null)
            {
                return NotFound();
            }

            var tbBlog = await _context.TbBlogs.FindAsync(id);
            if (tbBlog == null)
            {
                return NotFound();
            }
            ViewData["Idadmin"] = new SelectList(_context.TbAdmins, "Idadmin", "Name", tbBlog.Idadmin);
            return View(tbBlog);
        }

        // POST: Admin/Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Idblog,Detail,PublishTime,Description,Image,Idadmin")] TbBlog tbBlog)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            if (id != tbBlog.Idblog)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbBlog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbBlogExists(tbBlog.Idblog))
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
            ViewData["Idadmin"] = new SelectList(_context.TbAdmins, "Idadmin", "Name", tbBlog.Idadmin);
            return View(tbBlog);
        }

        // GET: Admin/Blogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            if (id == null)
            {
                return NotFound();
            }

            var tbBlog = await _context.TbBlogs
                .Include(t => t.IdadminNavigation)
                .FirstOrDefaultAsync(m => m.Idblog == id);
            if (tbBlog == null)
            {
                return NotFound();
            }

            return View(tbBlog);
        }

        // POST: Admin/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!Function.AdminIsLogin()) return Redirect("/Admin/Login");
            var tbBlog = await _context.TbBlogs.FindAsync(id);
            if (tbBlog != null)
            {
                _context.TbBlogComments.RemoveRange(tbBlog.TbBlogComments);
                _context.TbBlogs.Remove(tbBlog);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbBlogExists(int id)
        {
            return _context.TbBlogs.Any(e => e.Idblog == id);
        }
    }
}
