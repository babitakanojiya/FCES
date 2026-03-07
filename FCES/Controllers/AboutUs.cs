using Microsoft.AspNetCore.Mvc;

namespace FCES.Controllers
{
    public class AboutUs : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
