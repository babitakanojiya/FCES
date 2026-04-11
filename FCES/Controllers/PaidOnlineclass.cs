using FCES.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace FCES.Controllers
{
    public class PaidOnlineclass : Controller
    {
        private readonly IConfiguration _configuration;

        public PaidOnlineclass(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
        public IActionResult Index()
        {
            List<CourseModel> courses = new List<CourseModel>();

            try
            {
                string conStr = _configuration.GetConnectionString("DefaultConnection");

                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand(
                        @"SELECT ParentCourse, ChildCourse, VideoUrl 
                  FROM CourseMaster 
                  WHERE IsActive = 1
                  ORDER BY ParentCourse",
                        con);

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string url = dr["VideoUrl"]?.ToString();

                            // ✅ Fix YouTube URL
                            if (!string.IsNullOrEmpty(url) && url.Contains("watch?v="))
                            {
                                url = url.Replace("watch?v=", "embed/");
                            }

                            courses.Add(new CourseModel
                            {
                                ParentCourse = dr["ParentCourse"]?.ToString(),
                                ChildCourse = dr["ChildCourse"]?.ToString(),
                                VideoUrl = url
                            });
                        }
                    }
                }

                return View(courses);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(new List<CourseModel>());
            }
        }

        //public IActionResult Courses()
        //{
        //    List<CourseModel> courses = new List<CourseModel>();

        //    try
        //    {
        //        string conStr = _configuration.GetConnectionString("DefaultConnection");

        //        // ✅ Check connection string
        //        if (string.IsNullOrEmpty(conStr))
        //        {
        //            ViewBag.Error = "Database connection is not configured.";
        //            return View(courses);
        //        }

        //        using (SqlConnection con = new SqlConnection(conStr))
        //        {
        //            SqlCommand cmd = new SqlCommand(
        //                @"SELECT ParentCourse, ChildCourse, VideoUrl 
        //          FROM CourseMaster 
        //          WHERE IsActive = 1
        //          ORDER BY ParentCourse",
        //                con);

        //            con.Open();

        //            // ✅ Using block for reader (important)
        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                {
        //                    courses.Add(new CourseModel
        //                    {
        //                        // ✅ Null-safe reading
        //                        ParentCourse = dr["ParentCourse"]?.ToString(),
        //                        ChildCourse = dr["ChildCourse"]?.ToString(),
        //                        VideoUrl = dr["VideoUrl"]?.ToString()
        //                    });
        //                }
        //            }
        //        }

        //        // ✅ If no data found
        //        if (courses.Count == 0)
        //        {
        //            ViewBag.Message = "No courses available.";
        //        }

        //        return View(courses);
        //    }
        //    catch (Exception ex)
        //    {
        //        // ✅ Show error (for debugging or UI)
        //        ViewBag.Error = ex.Message;

        //        // You can log error here (recommended)
        //        // _logger.LogError(ex, "Error in Courses");

        //        return View(courses); // return empty list safely
        //    }
        //}
    }
}