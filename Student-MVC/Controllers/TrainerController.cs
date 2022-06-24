using Microsoft.AspNetCore.Mvc;
using Student_MVC.Db;
using Student_MVC.Models;

namespace Student_MVC.Controllers
{
    public class TrainerController : Controller
    {
        AppDb db = new AppDb();
        public IActionResult TrainerList()
        {
            int Id = Convert.ToInt32(HttpContext.Session.GetString("LoginId"));
            if (Id == 0)
            {
                return RedirectToAction("Login", "GeneralFunction");
            }
            return View(db.Trainers.ToList());//check login account & dont show yourself data in list
        }

        public IActionResult CreateTrainer()
        {
            int Id = Convert.ToInt32(HttpContext.Session.GetString("LoginId"));
            if (Id == 0)
            {
                return RedirectToAction("Login", "GeneralFunction");
            }
            return View();
        }
        [HttpPost]
        public IActionResult CreateTrainer(Trainer trainer)
        {
            db.Trainers.Add(trainer);
            db.SaveChanges();
            return RedirectToAction("TrainerList");
        }

        public IActionResult TrainerDetails(int Id)
        {
            int LoginId = Convert.ToInt32(HttpContext.Session.GetString("LoginId"));
            if (LoginId == 0)
            {
                return RedirectToAction("Login", "GeneralFunction");
            }
            var trainer = db.Trainers.Where(s => s.TrainerId == Id).First();
            return View(trainer);
        }

        public IActionResult EditTrainer(int Id)
        {
            int LoginId = Convert.ToInt32(HttpContext.Session.GetString("LoginId"));
            if (LoginId == 0)
            {
                return RedirectToAction("Login", "GeneralFunction");
            }
            return View(db.Trainers.Where(s => s.TrainerId == Id).First());
        }
        [HttpPost]
        public IActionResult EditTrainer(Trainer trainer)
        {
            var check = db.Trainers.Where(s=>s.TrainerId == trainer.TrainerId).First();
            check.TrainerName = trainer.TrainerName;
            check.Password = trainer.Password;
            db.SaveChanges();
            return RedirectToAction("TrainerList");
        }

        public IActionResult DeleteTrainer(int Id)
        {
            int LoginId = Convert.ToInt32(HttpContext.Session.GetString("LoginId"));
            if (LoginId == 0)
            {
                return RedirectToAction("Login", "GeneralFunction");
            }
            return View(db.Trainers.Where(s=>s.TrainerId == Id).First());
        }
        [HttpPost]
        public IActionResult DeleteTrainer(Trainer trainer)
        {
            db.Trainers.Remove(trainer);
            db.SaveChanges();
            return RedirectToAction("TrainerList");
        }
    }
}
