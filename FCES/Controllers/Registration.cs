using Microsoft.AspNetCore.Mvc;
using FCES.Data;
using FCES.Models;
using System;
using System.IO;
using System.Linq;

public class RegistrationController : Controller
{
    private readonly AppDbContext _context;
    private readonly IWebHostEnvironment _env;

    public RegistrationController(AppDbContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }

    public IActionResult Index()
    {
        return View("Registration");
    }

    public IActionResult Create()
    {
        return View("Registration"); // FIXED
    }

    [HttpPost]
    public IActionResult Register(Registration model, IFormFile Photo, IFormFile Resume, IFormFile Certificate)
    
    {
        ModelState.Remove("RegistrationNo");
        ModelState.Remove("PhotoPath");
        ModelState.Remove("ResumePath");
        ModelState.Remove("CertificatePath");
        ModelState.Remove("Photo");
        ModelState.Remove("Resume");
        ModelState.Remove("Certificate");
        if (ModelState.IsValid)
        {
            string regNo = "FCES" + Guid.NewGuid().ToString("N").Substring(0, 10).ToUpper();
            model.RegistrationNo = regNo;

            string folder = Path.Combine(_env.WebRootPath, "uploads");

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            // PHOTO
            if (Photo != null)
            {
                string photoName = regNo + "_photo" + Path.GetExtension(Photo.FileName);
                string path = Path.Combine(folder, photoName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    Photo.CopyTo(stream);
                }

                model.PhotoPath = "/uploads/" + photoName;
            }

            // RESUME
            if (Resume != null)
            {
                string resumeName = regNo + "_resume" + Path.GetExtension(Resume.FileName);
                string path = Path.Combine(folder, resumeName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    Resume.CopyTo(stream);
                }

                model.ResumePath = "/uploads/" + resumeName;
            }

            // CERTIFICATE
            if (Certificate != null)
            {
                string certName = regNo + "_certificate" + Path.GetExtension(Certificate.FileName);
                string path = Path.Combine(folder, certName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    Certificate.CopyTo(stream);
                }

                model.CertificatePath = "/uploads/" + certName;
            }

            try
            {
                _context.Registration.Add(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string error = ex.InnerException?.Message ?? ex.Message;
                ViewBag.Error = error;   // show on UI
                Console.WriteLine(error);
                return View("Registration");
            }

            // ✅ RETURN SAME PAGE WITH SUCCESS MESSAGE
            ViewBag.RegNo = regNo;
            ViewBag.Success = true;

            return View("Registration"); // FIXED
        }
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            foreach (var err in errors)
            {
                Console.WriteLine(err); // check in output
            }

            return View("Registration");
        }
        return View("Registration"); // FIXED
    }
}