using E_Book_eproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace E_Book_eproject.Controllers
{
    public class ProductController : Controller
    {
        EProjectContext db = new EProjectContext();
        public IActionResult Index()
        {
         var data = db.Products.ToList();
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
        [ValidateAntiForgeryToken]
        public ActionResult Store(Product pro, IFormFile Image)
        {
            try
            {
                string imagename = DateTime.Now.ToString("yymmddhhmmss");//2410152541245412
                imagename += "-" + Path.GetFileName(Image.FileName);//2410152541245412-sonata.jpg

                var imagepath = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/Uploads");
                var imageValue = Path.Combine(imagepath, imagename);

                using (var stream = new FileStream(imageValue, FileMode.Create))
                {
                    Image.CopyTo(stream);
                }

                var dbimage = Path.Combine("/Uploads", imagename);//Uploads/2410152541245412-sonata.jpg

                pro.Image = dbimage;

                db.Products.Add(pro);
                db.SaveChanges();

                TempData["SuccessMessage"] = "Product successfully inserted!";
                ViewBag.CatId = new SelectList(db.Categories, "Id", "Name");
                return RedirectToAction("Index");
            }
            catch
            {

                TempData["ErrorMessage"] = "Records Does not inserted!";

                return View();
            }
        }

        public IActionResult ProductDetails(int id)
        {
            var data = db.Products
                .Include(p => p.Cat) 
                .Include(p => p.Sub) 
                .FirstOrDefault(p => p.Id == id); 
            if (data == null)
            {
                return NotFound(); // Ya apna custom error page return karain
            }
            return View(data);
        }




    }
}
