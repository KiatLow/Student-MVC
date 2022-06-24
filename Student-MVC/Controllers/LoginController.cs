using Microsoft.AspNetCore.Mvc;
using Student_MVC.Db;

namespace Student_MVC.Controllers
{
    public class LoginController : Controller
    {
        AppDb db = new AppDb();
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var loginAccount = db.Trainers.Where(s => s.Username == username && s.Password == password).FirstOrDefault();
            if (loginAccount == null)
            {
                ViewBag.errorMsg = "Invalid Username or Password";
                return View();
            }
            else
            {
                HttpContext.Session.SetString("LoginId", loginAccount.TrainerId.ToString());
                return RedirectToAction("Menu", "Menu");
            }
        }
    }
}
