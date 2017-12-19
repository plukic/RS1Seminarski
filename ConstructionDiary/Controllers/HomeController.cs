using ConstructionDiary.ViewModels;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using GradjevinskiDnevnik.Models;
using ConstructionDiary.BR;
=======
using System.Diagnostics;
>>>>>>> c6c2264fed2c5d6624381982c00a3bb5fe273b9d

namespace ConstructionDiary.Controllers
{
    public class HomeController : Controller
    {
        IUserManagment userManagment;
        public HomeController(IUserManagment userManagment)
        {
            this.userManagment = userManagment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(UserLoginModel userLoginModel)
        {

            if (!ModelState.IsValid)
            {
                return PartialView("LoginView",userLoginModel);
            }
            userManagment.LoginUser(userLoginModel);
            return RedirectToAction("Index");
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
