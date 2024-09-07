using E_Book_eproject.Models;

using Microsoft.AspNetCore.Mvc;

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

			return View();
		}
		[HttpPost]
		public IActionResult create(Category cat ,IFormFile Image)
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

			cat.Image = dbimage;

			db.Categories.Add(cat);
			db.SaveChanges();


			return RedirectToAction("Index");
		}

		public IActionResult Delete(int Id)
		{
		var data = db.Categories.Find(Id);
			return View(data);
		}

		[HttpPost]
        public IActionResult Delete(Category cat)
        {
           db.Categories.Remove(cat);
			db.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Details(int Id)
        {
            var data = db.Categories.Find(Id);
            return View(data);
        }

      
    }
}
