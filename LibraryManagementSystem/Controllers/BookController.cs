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
            return RedirectToAction("Dashboard");
        }
        public IActionResult Dashboard()
        {
            var TotalCopies = _dbcontext.Books.Sum(x => x.TotalCopies);
            var Issued = _dbcontext.IssuedBooks.Count();
            return View();
        }
        public IActionResult CreateBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateBook(Book bk)
        {
            bk.CopiesLeft=bk.TotalCopies;
            _dbcontext.Books.Add(bk); 
            _dbcontext.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    }
}
