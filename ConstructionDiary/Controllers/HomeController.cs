using ConstructionDiary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ConstructionDiary.BR;
using System.Diagnostics;

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
        public IActionResult LogIn(UserLoginModel userLoginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = userManagment.LoginUser(userLoginModel);
            if (user == null)
                return ViewComponent("Login");

            return RedirectToAction("Index");
        }
        public IActionResult LogOut()
        {
            userManagment.LogoutUser();
            return RedirectToAction("Index");
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

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
    }
}
