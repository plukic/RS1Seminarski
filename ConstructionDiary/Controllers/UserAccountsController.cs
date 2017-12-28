using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionDiary.BR.UserManagment;
using ConstructionDiary.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace ConstructionDiary.Controllers
{
    [Authorize(Roles = "Manager")]
    public class UserAccountsController : Controller
    {
        IUserManagment userManagment;
        
        public UserAccountsController(IUserManagment userManagment)
        {
            this.userManagment = userManagment;
        }



        public IActionResult Index()
        {

            var users = userManagment.GetExistingUsers();
            IList<UserAccountIndexViewModel> usersVM = new List<UserAccountIndexViewModel>();
            foreach (var x in users)
            {
                usersVM.Add(new UserAccountIndexViewModel()
                {
                    Id = x.Id,
                    Email = x.Email,
                    FirstNameLastName = x.FirstName + " " +x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    Username = x.UserName
                });
            }

            return View(usersVM);
        }
        public IActionResult AddUser()
        {
            IList<SelectListItem>roles = userManagment.GetRoles();
            string password=  userManagment.GenerateUserRandomPassword();
            RegisterViewModel rvm = new RegisterViewModel
            {
                Roles = roles,
                Password = password
            };

            return View(rvm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser(RegisterViewModel obj)
        {
            if (ModelState.IsValid)
            {
                if (userManagment.CreateUserAsync(obj))
                {
                    return RedirectToAction("AddUser");
                }
                else
                {
                    ModelState.AddModelError("", "Greška prilikom kreiranja korisnika");
                }


            }
            obj.Roles = userManagment.GetRoles();
            return View(obj);
        }
        [HttpPost]
        public JsonResult ValidUsername(string UserName)
        {
            bool userExist = userManagment.UserExist(UserName);
           return Json(!userExist);
        }

        public IActionResult ResetPassword(string userId)
        {
            string newPassword = userManagment.ResetPassword(userId);

            var users = userManagment.GetExistingUsers();
            IList<UserAccountIndexViewModel> usersVM = new List<UserAccountIndexViewModel>();
            UserAccountIndexViewModel vm;
            foreach (var x in users)
            {
                vm = new UserAccountIndexViewModel()
                {
                    Id=x.Id,
                    Email = x.Email,
                    FirstNameLastName = x.FirstName + " " + x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    Username = x.UserName
                };
                if (x.Id.Equals(userId))
                {
                    vm.NewPassword = newPassword;
                    vm.HasResetPassword = true;
                }

                usersVM.Add(vm);
            }
            return View("Index",usersVM);
        }
    }
}