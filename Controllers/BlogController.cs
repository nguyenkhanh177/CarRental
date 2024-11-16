﻿using Microsoft.AspNetCore.Mvc;
using CarRental.Utilities;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
namespace CarRental.Controllers
{
    public class BlogController : Controller
    {
        private readonly CarRentalContext _context;

        static int idblogdetail;
        public BlogController(CarRentalContext context)
        {
            _context = context;
        }

        [Route("/blog/{id}.html")]
        public async Task<IActionResult> Detail(int id)
        {
            idblogdetail = id;
            if (id == null || _context.TbBlogs == null)
            { return RedirectToAction("Index", "404"); }
            var blog = _context.TbBlogs.Include(m => m.TbBlogComments).ThenInclude(m => m.IdcustomerNavigation).Where(m => m.Idblog == id).Include(m => m.IdadminNavigation).FirstOrDefault(m => m.Idblog == id);
            //var blog = _context.TbBlogs.Include(b => b.IdadminNavigation).Include(b => b.TbBlogComments).Where(b => b.TbBlogComments.Any(c => c.Idblog == id)).Select(b => new TbBlog { Idblog = b.Idblog, Title = b.Title, Detail = b.Detail, PublishTime = b.PublishTime, Description = b.Description, Idadmin = b.Idadmin, Image = b.Image, IdadminNavigation = b.IdadminNavigation, TbBlogComments = b.TbBlogComments.Where(c => c.Idblog == id).ToList() }).FirstOrDefault(m=>m.Idblog == id);

            if (blog == null)
            {
                return RedirectToAction("Index", "404");
            }
            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> comment(string detail)
        {
            if (ModelState.IsValid)
            {
                TbBlogComment tbBlogComment = new TbBlogComment
                {
                    Idblog = idblogdetail,
                    Detail = detail,
                    Idcustomer = 1,
                    Time = DateTime.Now
                };

                _context.Add(tbBlogComment);
                await _context.SaveChangesAsync();

            }
            return RedirectToAction("Detail",idblogdetail);
        }

        public IActionResult Index()
        {

            return View();
        }




        
    }
}
