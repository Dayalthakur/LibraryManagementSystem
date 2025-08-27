using System.Diagnostics;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LibraryManagementSystemContext _dbcontext;
        public HomeController(ILogger<HomeController> logger, LibraryManagementSystemContext dbcontext)
        {
            _logger = logger;
            _dbcontext = dbcontext;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserInfo user)
        {
            if (user != null)
            {
                var data = _dbcontext.UserInfos.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault();
                if (data != null)
                {
                    return RedirectToAction("Dashboard","Book");
                }
            }
            return RedirectToAction("Index");
        }

        
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserInfo user)
        {
            _dbcontext.UserInfos.Add(user);
            _dbcontext.SaveChanges();
            return RedirectToAction("Login");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
