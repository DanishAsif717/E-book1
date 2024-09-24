using E_Book_eproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Book_eproject.Controllers
{
    public class StationaryController : Controller
    {
        EProjectContext db = new EProjectContext();
        public IActionResult Index()
        {
            var data  = db.Stationaries.ToList();
            return View(data);
        }
        public ActionResult create()
        {
            ViewBag.CatId = new SelectList(db.Categories, "Id", "Name");

            ViewBag.SubId = new SelectList(Enumerable.Empty<SelectListItem>(), "Id", "Name"); // Empty initially

            return View();
        }
        [HttpGet]
        public JsonResult GetSubCategories(int catId)
        {
            var subCategories = db.SubCategories
                                        .Where(sc => sc.CatId == catId)
                                        .Select(sc => new { sc.Id, sc.Name })
                                        .ToList();
            return Json(subCategories);
        }

        [HttpPost]
        public IActionResult Store(Product product ,IFormFile Image)
        {

            string imagename = DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + Path.GetFileName(Image.FileName);
            var imagepath = Path.Combine("wwwroot/Uploads", imagename); // Corrected path
            using (var stream = new FileStream(imagepath, FileMode.Create))
            {
                Image.CopyTo(stream);
            }

            var dbimage = Path.Combine("/Uploads", imagename);
            product.Image = dbimage; // Set the image path in the user object

            db.Products.Add(product);
            db.SaveChanges();
             TempData["SuccessMessage"] = "Product successfully inserted!";
                ViewBag.CatId = new SelectList(db.Categories, "Id", "Name");
                return RedirectToAction("Index");
        }

    }
}
