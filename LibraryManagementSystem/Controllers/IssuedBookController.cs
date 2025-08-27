using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.Controllers
{
    public class IssuedBookController : Controller
    {
        private readonly LibraryManagementSystemContext _dbcontext;
        public IssuedBookController(LibraryManagementSystemContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IActionResult IssueBook()
        {
            var books=_dbcontext.Books.ToList();
            ViewBag.BookList = new SelectList(books, "BookId", "Title");
            return View();
        }
        [HttpPost]
        public IActionResult IssueBook(IssuedBook issuedBook)
        {
            _dbcontext.IssuedBooks.Add(issuedBook);
            _dbcontext.SaveChanges();
            return RedirectToAction("Dashboard","Book");
        }
    }
}
