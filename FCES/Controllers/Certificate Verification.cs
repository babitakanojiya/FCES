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
            ViewBag.HasSearched = true;
            var data = _context.Certificates
                .FirstOrDefault(x => x.CertificateNo == certificateNo);

            if (data == null)
            {
                ViewBag.IsValid = false;
                ViewBag.Message = "Certificate is not available. Please complete your course and register.";
                return View("Index");
            }

            ViewBag.IsValid = true;
            return View("Index", data);
        }
    }
}