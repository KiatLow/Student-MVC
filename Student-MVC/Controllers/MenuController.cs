using Microsoft.AspNetCore.Mvc;

namespace Student_MVC.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Menu()
        {
            int Id = Convert.ToInt32(HttpContext.Session.GetString("LoginId"));
            if (Id == 0)
            {
                return RedirectToAction("Login", "GeneralFunctions");
            }
            return View();
        }
    }
}
