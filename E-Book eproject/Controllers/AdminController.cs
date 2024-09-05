using Microsoft.AspNetCore.Mvc;

namespace E_Book_eproject.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
