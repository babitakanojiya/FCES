using Microsoft.AspNetCore.Mvc;
using FCES.Models;

namespace FCES.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Thank you! Our team will contact you soon.";
            }

            return View(model);
        }
    }
}
