using Microsoft.AspNetCore.Mvc;
using Student_MVC.Db;
using Student_MVC.Models;

namespace Student_MVC.Controllers
{
    public class CourseController : Controller
    {
        AppDb db = new AppDb();
        public IActionResult CourseList()
        {
            int Id = Convert.ToInt32(HttpContext.Session.GetString("LoginId"));
            if (Id == 0)
            {
                return RedirectToAction("Login", "Login");
            }
            return View(db.Courses.ToList()); ;
        }

        public IActionResult CreateCourse()
        {
            int Id = Convert.ToInt32(HttpContext.Session.GetString("LoginId"));
            if (Id == 0)
            {
                return RedirectToAction("Login", "GeneralFunction");
            }
            return View();
        }
        [HttpPost]
        public IActionResult CreateCourse(Course course)
        {
            db.Courses.Add(course);
            db.SaveChanges();
            return RedirectToAction("CourseList");
        }

        public IActionResult CourseDetails(int Id)
        {
            int LoginId = Convert.ToInt32(HttpContext.Session.GetString("LoginId"));
            if (LoginId == 0)
            {
                return RedirectToAction("Login", "GeneralFunction");
            }
            return View(db.Courses.Where(s => s.CourseId == Id).First());
        }

        public IActionResult EditCourse(int Id)
        {
            int LoginId = Convert.ToInt32(HttpContext.Session.GetString("LoginId"));
            if (LoginId == 0)
            {
                return RedirectToAction("Login", "GeneralFunction");
            }
            return View(db.Courses.Where(s => s.CourseId == Id).First());
        }
        [HttpPost]
        public IActionResult EditCourse(Course course)
        {
            var check = db.Courses.Where(s => s.CourseId == course.CourseId).First();
            check.CourseName = course.CourseName;
            db.SaveChanges();
            return RedirectToAction("CourseList");
        }

        public IActionResult DeleteCourse(int Id)
        {
            int LoginId = Convert.ToInt32(HttpContext.Session.GetString("LoginId"));
            if (LoginId == 0)
            {
                return RedirectToAction("Login", "GeneralFunction");
            }
            return View(db.Courses.Where(s => s.CourseId == Id).First());
        }
        [HttpPost]
        public IActionResult DeleteCourse(Course course)
        {
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("CourseList");
        }
    }
}
