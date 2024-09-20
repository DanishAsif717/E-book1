using E_Book_eproject.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Store(Stationary stationary ,IFormFile Image)
        {

            string imagename = DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + Path.GetFileName(Image.FileName);
            var imagepath = Path.Combine("wwwroot/Uploads", imagename); // Corrected path
            using (var stream = new FileStream(imagepath, FileMode.Create))
            {
                Image.CopyTo(stream);
            }

            var dbimage = Path.Combine("/Uploads", imagename);
            stationary.Image = dbimage; // Set the image path in the user object

            db.Stationaries.Add(stationary);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
