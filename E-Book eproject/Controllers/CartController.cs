using E_Book_eproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Book_eproject.Controllers
{
    public class CartController : Controller
    {
        EProjectContext db = new EProjectContext();
        [HttpPost]
        public IActionResult AddCart(Cart cart)
        {
            db.Carts.Add(cart);
            db.SaveChanges();
            return RedirectToAction("Home" ,"shop");
        }
    }
}
