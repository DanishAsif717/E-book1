using E_Book_eproject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace E_Book_eproject.Controllers
{
    public class BookController : Controller
    {
        EProjectContext db = new EProjectContext();
        // GET: BookController
        public ActionResult Index()
        {
            var data = db.Books.Include(b=> b.Cat).ToList();
            return View(data);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
             var data = db.Books.Include(b=> b.Cat);
             var detail =data.FirstOrDefault(b => b.Id == id);
            return View(detail);
        }
        public ActionResult Create()
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

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Store(Book book , IFormFile Image)
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

                book.Image = dbimage;

                db.Books.Add(book);
                db.SaveChanges();

                TempData["SuccessMessage"] = "Books successfully inserted!";
                ViewBag.CatId = new SelectList(db.Categories, "Id", "Name");

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = db.Books.Include(b => b.Cat);
            var detail = data.FirstOrDefault(b => b.Id == id);
            return View(detail);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteData(Book book)
        {
           
                db.Books.Remove(book);
                db.SaveChanges();
                TempData["DeleteMessage"] = "Record successfully deleted!";

                return RedirectToAction(nameof(Index));
            
           
        }


        public ActionResult productdetail(int id)
        {
            var data = db.Books.Include(b => b.Cat);
            var detail = data.FirstOrDefault(b => b.Id == id);
            return View(detail);
        }
    }
}
