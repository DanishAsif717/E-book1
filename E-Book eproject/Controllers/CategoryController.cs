using E_Book_eproject.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Book_eproject.Controllers
{

	public class CategoryController : Controller
	{
		EProjectContext db = new EProjectContext();
		public IActionResult Index()
		{
			var data = db.Categories.ToList();
			return View(data);
		}
		public IActionResult create()
		{
			ViewBag.SubId = new SelectList(db.SubCategories,"Id","Name");
			return View();
		}
		[HttpPost]
		public IActionResult create(Category category)
		{
			db.Categories.Add(category);
			db.SaveChanges();
            TempData["SuccessMessage"] = "Category successfully inserted!";

            return RedirectToAction("index");
		}
		

		public IActionResult Delete(int Id)
		{
		var data = db.Categories.Find(Id);
			return View(data);
		}

		[HttpPost]
        public IActionResult Delete(Category cat)
        {
           
            if (cat != null)
            {
                var prds = db.Products.Where(u => u.SubId == cat.Id).ToList();
                var subcats = db.SubCategories.Where(u => u.CatId == cat.Id).ToList();
                foreach (var item in prds)
                {

                    db.Products.Remove(item);
                    db.SaveChanges();
                }
                  foreach (var item in subcats)
                {

                    db.SubCategories.Remove(item);
                    db.SaveChanges();
                }

                db.Categories.Remove(cat);
                db.SaveChanges();

                // Success message for delete operation
                TempData["DeleteMessage"] = "Record successfully deleted!";
            }
            else
            {
                TempData["DeleteMessage"] = "Record not found!";
            }
            return RedirectToAction("index");
        }

        public IActionResult Details(int Id)
        {
            var data = db.Categories.Find(Id);
            return View(data);
        }

      
    }
}
