using ConstructionDiary.BR;
using ConstructionDiary.BR.UserManagment;
using ConstructionDiary.ViewModels;
using DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionDiary.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> loginManager;
        private readonly RoleManager<Role> roleManager;

        public LoginController(UserManager<User> userManager,
                            SignInManager<User> loginManager,
                            RoleManager<Role> roleManager)
        {
            this.userManager = userManager;
            this.loginManager = loginManager;
            this.roleManager = roleManager;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserLoginViewModel obj)
        {
            if (ModelState.IsValid)
            {
                User u = userManager.FindByNameAsync(obj.Username).Result;
                
                if(u!=null && u.IsDeleted)
                {
                    ModelState.AddModelError("", "Korisnik nije aktivan");
                    return View("Index", obj);
                }

                var result = loginManager.PasswordSignInAsync
                (obj.Username, obj.Password, obj.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Pogrešni login podaci!");
            }

            return View("Index",obj);
        }
        public IActionResult LogOut()
        {
            loginManager.SignOutAsync().Wait();
            return RedirectToAction("Index","Home");
        }

        public IActionResult Register()
        {

            return View();
        }
     
        public IActionResult Index()
        {
            return View();
        }
    }
}