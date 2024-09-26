using E_Book_eproject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Book_eproject.Controllers
{
    public class CartController : Controller
    {
        EProjectContext db = new EProjectContext();
        [HttpPost]
        public IActionResult AddToCart(Cart cart)
        {
            var userId = User.FindFirstValue(ClaimTypes.Sid); 

            if (userId != null)
            {
                cart.UserId = Convert.ToInt32(userId);

                db.Carts.Add(cart);
                db.SaveChanges();

                return RedirectToAction("Shop" , "Home");
            }
            else
            {
                return RedirectToAction("Login", "Auth"); 
            }
        }














        public IActionResult CheckOut(string cartId) 
        {
            var data= db.Orders.ToList();
            return View(data);
        }
    }
}
