using E_Book_eproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Book_eproject.Controllers
{
    public class SubCategoryController : Controller
    {
        EProjectContext db = new EProjectContext(); 
        public IActionResult Index()
        {
            var data = db.SubCategories.ToList();
            return View(data);
        }

        public IActionResult create()
        {
            var categories = db.Categories.ToList();

            ViewBag.CatId = new SelectList(categories, "Id", "Name");

            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult store(SubCategory sub, IFormFile Image)
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

            sub.Image = dbimage;

            db.SubCategories.Add(sub);
            db.SaveChanges();

            TempData["SuccessMessage"] = "SubCategory successfully inserted!";

            return RedirectToAction("Index");
        }



        public IActionResult delete(int id )

        {
         var data =   db.SubCategories.Find(id);
            db.SubCategories.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
