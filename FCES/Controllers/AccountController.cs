using Microsoft.AspNetCore.Mvc;
using FCES.Models;
using FCES.Data;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace FCES.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _context.Users.FirstOrDefault(x =>
                (x.Email == model.Username || x.Mobile == model.Username)
                && x.Password == model.Password);

            if (user == null)
            {
                //ViewBag.ShowSignup = true;
                ViewBag.Error = "User not found. Please sign up.";
                ViewBag.HighlightSignup = true; // only highlight
                return View(model);
            }

            HttpContext.Session.SetString("UserName", user.Name);
            HttpContext.Session.SetString("UserRole", user.Role);

            if (user.Role == "Admin")
                return RedirectToAction("Dashboard", "Admin");

            return RedirectToAction("Index", "PaidOnlineClass");
        }

        [HttpPost]
        public IActionResult Register(User user, string ConfirmPassword)
        {
            if (user.Password != ConfirmPassword)
            {
                ViewBag.Error = "Passwords do not match";
                return View("Login");
            }
            user.Role = "User";

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}