using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Student_MVC.Db;
using Student_MVC.Models;

namespace Student_MVC.Controllers
{
    public class StudentCourseController : Controller
    {
        AppDb db = new AppDb();
        public IActionResult StudentCourseList()
        {
            int Id = Convert.ToInt32(HttpContext.Session.GetString("LoginId"));
            if (Id == 0)
            {
                return RedirectToAction("Login", "GeneralFunction");
            }
            db.Students.ToList();
            db.Courses.ToList();
            db.Trainers.ToList();
            return View(db.StudentCourses.ToList());
        }

        public IActionResult CreateStudentCourse()
        {
            var students = db.Students.ToList();
            var courses = db.Courses.ToList();
            var trainers = db.Trainers.ToList();
            ViewBag.Student = new SelectList(students, "StudentId", "StudentName", students);
            ViewBag.Course = new SelectList(courses, "CourseId", "CourseName", courses);
            ViewBag.Trainer = new SelectList(trainers, "TrainerId", "TrainerName", trainers);
            return View();
        }
        [HttpPost]
        public IActionResult CreateStudentCourse(StudentCourse studentCourse)
        {
            studentCourse.Student = db.Students.Where(s => s.StudentId == studentCourse.Student.StudentId).First();
            studentCourse.Course = db.Courses.Where(s => s.CourseId == studentCourse.Course.CourseId).First();
            studentCourse.Trainer = db.Trainers.Where(s => s.TrainerId == studentCourse.Trainer.TrainerId).First();

            db.StudentCourses.Add(studentCourse);
            db.SaveChanges();
            return RedirectToAction("StudentCourseList");
        }

        public IActionResult StudentCourseDetails(int Id)
        {
            int LoginId = Convert.ToInt32(HttpContext.Session.GetString("LoginId"));
            if (LoginId == 0)
            {
                return RedirectToAction("Login", "GeneralFunction");
            }
            db.Students.ToList();
            db.Courses.ToList();
            db.Trainers.ToList();
            return View(db.StudentCourses.Where(s => s.StudentCourseId == Id).First());
        }

        public IActionResult EditStudentCourse(int Id)
        {
            int LoginId = Convert.ToInt32(HttpContext.Session.GetString("LoginId"));
            if (LoginId == 0)
            {
                return RedirectToAction("Login", "GeneralFunction");
            }

            var students = db.Students.ToList();
            var courses = db.Courses.ToList();
            var trainers = db.Trainers.ToList();
            ViewBag.Student = new SelectList(students, "StudentId", "StudentName", students);
            ViewBag.Course = new SelectList(courses, "CourseId", "CourseName", courses);
            ViewBag.Trainer = new SelectList(trainers, "TrainerId", "TrainerName", trainers);
            return View(db.StudentCourses.Where(s => s.StudentCourseId == Id).First());
        }
        [HttpPost]
        public IActionResult EditStudentCourse(StudentCourse studentCourse)
        {
            var studentcourse = db.StudentCourses.Where(s => s.StudentCourseId == studentCourse.StudentCourseId).First();
            studentcourse.Student = db.Students.Where(s => s.StudentId == studentCourse.Student.StudentId).First();
            studentcourse.Course = db.Courses.Where(s => s.CourseId == studentCourse.Course.CourseId).First();
            studentcourse.Trainer = db.Trainers.Where(s => s.TrainerId == studentCourse.Trainer.TrainerId).First();
            studentcourse.Score = studentCourse.Score;

            db.SaveChanges();
            return RedirectToAction("StudentCourseList");
        }

        public IActionResult DeleteStudentCourse(int Id)
        {
            int LoginId = Convert.ToInt32(HttpContext.Session.GetString("LoginId"));
            if (LoginId == 0)
            {
                return RedirectToAction("Login", "GeneralFunction");
            }
            db.Students.ToList();
            db.Courses.ToList();
            db.Trainers.ToList();
            return View(db.StudentCourses.Where(s => s.StudentCourseId == Id).First());
        }
        [HttpPost]
        public IActionResult DeleteStudentCourse(StudentCourse studentCourse)
        {
            db.StudentCourses.Remove(studentCourse);
            db.SaveChanges();
            return RedirectToAction("StudentCourseList");
        }
    }
}
