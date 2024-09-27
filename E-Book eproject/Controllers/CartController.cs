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

                return RedirectToAction("CheckOuts");
            }
            else
            {
                return RedirectToAction("Login", "Auth"); 
            }

        }


        public IActionResult CheckOuts()
        {
            var userId = User.FindFirstValue(ClaimTypes.Sid);

            if (userId != null)
            {
                int UserId = Convert.ToInt32(userId);

                // Joining Cart with Product using ProductId
                var cartItems = (from cart in db.Carts
                                 join product in db.Products
                                 on cart.ProductId equals product.Id
                                 where cart.UserId == UserId
                                 select new
                                 {
                                     cart.Id,
                                     cart.Quantity,
                                     product.Name,
                                     product.Price,
                                     product.Image
                                 }).ToList();

                // Pass the data to the view
                return View(cartItems);
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }











    }
}
