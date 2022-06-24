using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Student_MVC.Db;
using Student_MVC.Models;

namespace Student_MVC.Controllers
{
    public class StudentController : Controller
    {
        AppDb db = new AppDb();
        public IActionResult StudentList()
        {
            int Id = Convert.ToInt32(HttpContext.Session.GetString("LoginId"));
            if (Id == 0)
            {
                return RedirectToAction("Login", "GeneralFunction");
            }
            return View(db.Students.ToList());
        }

        public IActionResult CreateStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("StudentList");
        }

        public IActionResult StudentDetails(int Id)
        {
            int LoginId = Convert.ToInt32(HttpContext.Session.GetString("LoginId"));
            if (LoginId == 0)
            {
                return RedirectToAction("Login", "GeneralFunction");
            }
            return View(db.Students.Where(s=>s.StudentId == Id).First());
        }

        public IActionResult EditStudent(int Id)
        {
            int LoginId = Convert.ToInt32(HttpContext.Session.GetString("LoginId"));
            if (LoginId == 0)
            {
                return RedirectToAction("Login", "GeneralFunction");
            }
            return View(db.Students.Where(s => s.StudentId == Id).First());
        }
        [HttpPost]
        public IActionResult EditStudent(Student student)
        {
            var check = db.Students.Where(s=>s.StudentId == student.StudentId).First();
            check.StudentName = student.StudentName;
            check.StudentAge = student.StudentAge;
            check.Gender = student.Gender;
            db.SaveChanges();
            return RedirectToAction("StudentList");
        }

        public IActionResult DeleteStudent(int Id)
        {
            int LoginId = Convert.ToInt32(HttpContext.Session.GetString("LoginId"));
            if (LoginId == 0)
            {
                return RedirectToAction("Login", "GeneralFunction");
            }
            return View(db.Students.Where(s=>s.StudentId == Id).First());
        }
        [HttpPost]
        public IActionResult DeleteStudent(Student student)
        {
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("StudentList");
        }
    }
}
