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
        public IActionResult store(SubCategory sub)
        {         

            db.SubCategories.Add(sub);
            db.SaveChanges();

            TempData["SuccessMessage"] = "SubCategory successfully inserted!";

            return RedirectToAction("Index");
        }



        public IActionResult delete(int id )

        {
            var prds=  db.Products.Where(u=> u.SubId == id).ToList();
            foreach(var item in prds)
            {
                db.Products.Remove(item);   
                db.SaveChanges();
            }

            var cat = db.Stationaries.Where(u => u.CatId == id).ToList();
            foreach (var item in cat)
            {
                db.Stationaries.Remove(item);
                db.SaveChanges();
            }

            var data =   db.SubCategories.Find(id);
            db.SubCategories.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
