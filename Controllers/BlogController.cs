using Microsoft.AspNetCore.Mvc;
using CarRental.Utilities;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
namespace CarRental.Controllers
{
    public class BlogController : Controller
    {
        private readonly CarRentalContext _context;

        static int? idblogdetail;
        public BlogController(CarRentalContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Login()
        {
            Function._ReturnLink = "/Blog";
            return RedirectToAction("Index", "Login");
        }

        [Route("/blog/{id}.html")]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null || _context.TbBlogs == null)
            { return RedirectToAction("Index", "404"); }
            var blog = _context.TbBlogs.Include(m => m.TbBlogComments).ThenInclude(m => m.IdcustomerNavigation).Where(m => m.Idblog == id).Include(m => m.IdadminNavigation).FirstOrDefault(m => m.Idblog == id);
            if (blog == null)
            {
                return RedirectToAction("Index", "404");
            }
            idblogdetail = id;
            ViewBag.BlogOther = _context.TbBlogs.Where(i => i.Idblog != id).Take(15).OrderByDescending(i => i.PublishTime).ToList();
            return View(blog);
        }

        public IActionResult LoginDetail()
        {
            Function._ReturnLink = $"/blog/{idblogdetail}.html";
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> comment(string detail, int id)
        {
            if (ModelState.IsValid)
            {
                TbBlogComment tbBlogComment = new TbBlogComment
                {
                    Idblog = idblogdetail,
                    Detail = detail,
                    Idcustomer = Function._IdCustomer,
                    Time = DateTime.Now
                };

                _context.Add(tbBlogComment);
                await _context.SaveChangesAsync();

            }
            return RedirectToAction("Detail", new { id = idblogdetail });
        }

        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _context.TbBlogComments.FindAsync(id);
            if (comment != null)
            {
                idblogdetail = comment.Idblog;
                _context.Remove(comment);
                _context.SaveChanges();
            }
            return Redirect($"/blog/{idblogdetail}.html");
        }
    }
}
