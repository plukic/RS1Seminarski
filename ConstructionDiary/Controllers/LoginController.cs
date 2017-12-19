using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionDiary.BR;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionDiary.Controllers
{
    public class LoginController : Controller
    {
        IUserManagment userManagment;
        public LoginController(IUserManagment userManagment)
        {
            this.userManagment = userManagment;
        }

        public IActionResult LogIn(UserLoginModel userLoginModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.Clear();
                ModelState.AddModelError(string.Empty, "Podaci nisu validni");
                return View("Index",userLoginModel);
            }

            var user = userManagment.LoginUser(userLoginModel);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Podaci nisu validni");
                return View("Index", userLoginModel);
            }
            return RedirectToAction("Index","Home");
        }
        public IActionResult LogOut()
        {
            userManagment.LogoutUser();
            return RedirectToAction("Index","Home");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}