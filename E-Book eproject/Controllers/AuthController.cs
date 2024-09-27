using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using E_Book_eproject.Models;
using Microsoft.AspNetCore.Identity;

namespace E_Book_eproject.Controllers
{
    public class AuthController : Controller
    {

        EProjectContext db = new EProjectContext();
       
        public IActionResult Delete(int id)
        {
            var data = db.Users.Find(id);
            db.Users.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult index()
        {
            var data = db.Users.ToList();   
            return View(data);
        }
        public IActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SignUp(User user, IFormFile Image)
        {
            string imagename = DateTime.Now.ToString("yymmddhhmmss");//2410152541245412
            imagename += "-" + Path.GetFileName(Image.FileName);//2410152541245412-sonata.jpg

            var imagepath = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/Uploads");
            var imageValue = Path.Combine(imagepath, imagename);

            using (var stream = new FileStream(imageValue, FileMode.Create))
            {
                Image.CopyTo(stream);
            };

            var dbimage = Path.Combine("/Uploads", imagename);//Uploads/2410152541245412-sonata.jpg

            user.Image = dbimage;
            user.Role = 2;


            var hasher = new PasswordHasher<string>();
            string hasherPassword = hasher.HashPassword(user.Email , user.Password);
            user.Password = hasherPassword;
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Login(User user)
        {
            bool isAuthenticated = false;
            string controller = "";
            string action = "index";
            ClaimsIdentity identity = null;

            var Checkuser = db.Users.FirstOrDefault(a => a.Email == user.Email);

            if (Checkuser != null)
            {
                var hasher = new PasswordHasher<string>();

                var verifyPassword = hasher.VerifyHashedPassword(user.Email, Checkuser.Password, user.Password);

                if (verifyPassword == PasswordVerificationResult.Success && Checkuser.Role == 1)
                {
                    identity = new ClaimsIdentity(new[]
                    {
                new Claim(ClaimTypes.Name, Checkuser.Name),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Sid ,Checkuser.Id.ToString()),
                new Claim(ClaimTypes.Email ,Checkuser.Email),

                },
                    CookieAuthenticationDefaults.AuthenticationScheme);

                    isAuthenticated = true;
                    controller = "Admin";
                    //HttpContext.Session.SetString("UserId", Checkuser.Id.ToString());

                }
                else if (verifyPassword == PasswordVerificationResult.Success && Checkuser.Role == 2)
                {
                    identity = new ClaimsIdentity(new[]
                    {
                new Claim(ClaimTypes.Name, Checkuser.Name),
                new Claim(ClaimTypes.Role, "User"),
                new Claim(ClaimTypes.Sid ,Checkuser.Id.ToString() ),
                new Claim(ClaimTypes.Email ,Checkuser.Email),

            },
                    CookieAuthenticationDefaults.AuthenticationScheme);

                    isAuthenticated = true;
                    controller = "Home";
                     action = "Shop";
                    //HttpContext.Session.SetString("UserId", Checkuser.Id.ToString());

                }
                else
                {
                    ViewBag.Message = "Invalid credentials";
                    return View();
                }

                if (isAuthenticated)
                {
                    var principle = new ClaimsPrincipal(identity);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);

                    // User ID ko session mein store karna
                    //HttpContext.Session.SetString("UserId", Checkuser.Id.ToString());

                    return RedirectToAction(action, controller);
                }
                else
                {
                    ViewBag.msg = "Login failed";
                    return View();
                }
            }

            ViewBag.Message = "User not found";
            return View();
        }


        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Auth");
        }

        public IActionResult Profileupdate (int id)
        {
            var data = db.Users.FirstOrDefault(u => u.Id == id);
            return View(data);
        }

        [HttpPost]
        public IActionResult ProfileModify(User user, IFormFile Image, string OldImage)
        {


            if (Image != null)
            {
                string imagename = DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + Path.GetFileName(Image.FileName);
                var imagepath = Path.Combine("wwwroot/Uploads", imagename); // Corrected path
                using (var stream = new FileStream(imagepath, FileMode.Create))
                {
                    Image.CopyTo(stream);
                }

                var dbimage = Path.Combine("/Uploads", imagename);
                user.Image = dbimage; // Set the image path in the user object
            }
            else
            {
                user.Image = OldImage;
            }

            user.Role = 1;

            var hasher = new PasswordHasher<string>();
            string hasherPassword = hasher.HashPassword(user.Email, user.ConfirmPassword);
            user.Password = hasherPassword;

            db.Users.Update(user);
            db.SaveChanges();

            // Return the view with the updated user model to stay on the same page
            return View("ProfileUpdate", user);
        }
    }
}
