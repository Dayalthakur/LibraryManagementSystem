using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryManagementSystemContext _dbcontext;
        public BookController(LibraryManagementSystemContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book bk)
        {
            _dbcontext.Books.Add(bk);
            _dbcontext.SaveChanges();
            return RedirectToAction("Dashboard", "Home");
        }
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
