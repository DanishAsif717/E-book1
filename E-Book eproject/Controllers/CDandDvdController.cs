using E_Book_eproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace E_Book_eproject.Controllers
{
    public class CDandDvdController : Controller
    {
        EProjectContext db = new EProjectContext();
        // GET: Cd_DvdsController
        public ActionResult Index()
        {
            var data = db.CdandDvds.Include(cd => cd.Cat);
            return View(data.ToList());
        }

        // GET: Cd_DvdsController/Create
        public ActionResult Create()
        {
            ViewBag.CatId = new SelectList(db.Categories, "Id", "Name");

            ViewBag.SubId = new SelectList(Enumerable.Empty<SelectListItem>(), "Id", "Name"); // Empty initially

            return View();
        }

        // POST: Cd_DvdsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Store(CdandDvd cdandDvd, IFormFile Image)
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

                cdandDvd.Image = dbimage;

                db.CdandDvds.Add(cdandDvd);
                db.SaveChanges();

                TempData["SuccessMessage"] = "Records successfully inserted!";
                ViewBag.CatId = new SelectList(db.Categories, "Id", "Name");
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                TempData["ErrorMessage"] = "Records Does not inserted!";

                return View();
            }
        }


        // GET: Cd_DvdsController/Details/5
        public ActionResult Details(int id)
        {
            var data = db.CdandDvds.Include(cd => cd.Cat);
            var cd = data.FirstOrDefault(cd => cd.Id == id);
            return View();
        }

        public ActionResult Delete(int id)
        {
            var data = db.CdandDvds.Include(cd => cd.Cat);
            var cd = data.FirstOrDefault(cd => cd.Id == id);
            return View();
        }
        [HttpPost]
        public ActionResult Delete(CdandDvd cd)
        {
            db.CdandDvds.Remove(cd);
            db.SaveChanges();
            TempData["SuccessMessage"] = "Records successfully Deleted!";

            return View("Index");
        }
    }
}
