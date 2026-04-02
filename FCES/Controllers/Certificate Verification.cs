using Microsoft.AspNetCore.Mvc;
using FCES.Data;
using System.Linq;

namespace FCES.Controllers
{
    public class Certificate_Verification : Controller
    {
        private readonly AppDbContext _context;

        public Certificate_Verification(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Verify(string certificateNo)
        {
            var data = _context.Certificates
                .FirstOrDefault(x => x.CertificateNo == certificateNo);

            if (data == null)
            {
                ViewBag.Message = "Data not found, please register";
                return View("Index");
            }

            return View("CertificateView", data);
        }
    }
}