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
#pragma warning disable CS8629 // Nullable value type may be null.
                var cartItems = (from cart in db.Carts
                                 join product in db.Products
                                 on cart.ProductId equals product.Id
                                 where cart.UserId == UserId
                                 select new CartViewModel
                                 {
                                     Id = cart.Id,
                                     Quantity = cart.Quantity,
                                     Name = product.Name,
                                     Price = (int)product.Price,
                                     Image = product.Image
                                 }).ToList();



                // Pass the data to the view
                return View(cartItems);
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }




        public IActionResult DeleteProductFromCart(int cartId)
        {
            var cartItem = db.Carts.FirstOrDefault(c => c.Id == cartId);

            if (cartItem != null)
            {
                db.Carts.Remove(cartItem);
                db.SaveChanges();
            }

            return RedirectToAction("CheckOuts"); // Wapas CheckOut page par redirect karen
        }







    }
}
