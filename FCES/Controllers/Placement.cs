using Microsoft.AspNetCore.Mvc;

namespace FCES.Controllers
{
    public class PlacementController : Controller
    {
        public IActionResult Index()
        {
            return View("Placement");
        }
    }
}