using Microsoft.AspNetCore.Mvc;
using FCES.Models;
using Microsoft.Data.SqlClient;

namespace FCES.Controllers
{
    public class ContactController : Controller
    {
        private readonly IConfiguration _config;

        public ContactController(IConfiguration config)
        {
            _config = config;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        // POST
        [HttpPost]
        public IActionResult Index(ContactModel model)   // ✅ FIXED MODEL NAME
        {
            if (ModelState.IsValid)
            {
                string connStr = _config.GetConnectionString("DefaultConnection")!;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = @"INSERT INTO ContactDetails 
                                    (FullName, MobileNumber, Email, Message) 
                                    VALUES (@FullName, @Mobile, @Email, @Message)";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@FullName", model.FullName);
                    cmd.Parameters.AddWithValue("@Mobile", model.MobileNumber);
                    cmd.Parameters.AddWithValue("@Email", model.Email);
                    cmd.Parameters.AddWithValue("@Message", model.Message ?? "");

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                TempData["Success"] = "Thank you! Our team will contact you soon.";

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}