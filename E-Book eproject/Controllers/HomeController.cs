using System.Diagnostics;

using E_Book_eproject.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Book_eproject.Controllers
{
    public class HomeController : Controller
    {
        EProjectContext db = new EProjectContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult shop()
        {
            var data = db.Books.Include(b => b.Cat).ToList();
            return View(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}