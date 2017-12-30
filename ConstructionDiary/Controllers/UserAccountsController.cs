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
using ConstructionDiary.ViewModels.UserAccounts;

namespace ConstructionDiary.Controllers
{
    [Authorize(Roles = "Manager, ConstructionSiteManager")]
    public class UserAccountsController : Controller
    {
        IUserManagment userManagment;

        public UserAccountsController(IUserManagment userManagment)
        {
            this.userManagment = userManagment;
        }


        [Authorize(Roles = "Manager")]
        public IActionResult Index(string userName, DateTime? birthDate)
        {
            ViewData["username"] = userName;
            ViewData["birthDate"] = birthDate;
            List<UserAccountIndexViewModel> usersVM = PrepareUserAccountIndexViewModel()
                .Where(x => (string.IsNullOrEmpty(userName) || x.Username.Contains(userName)) && (birthDate == null || x.BirthDate.Equals(birthDate)))
                .ToList();
            return View(usersVM);
        }


        [Authorize(Roles = "Manager")]
        public IActionResult AddUser()
        {
            IList<SelectListItem> roles = userManagment.GetRoles();
            string password = userManagment.GenerateUserRandomPassword();
            RegisterViewModel rvm = new RegisterViewModel
            {
                Roles = roles,
                Password = password
            };

            return View(rvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
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


        [Authorize(Roles = "Manager")]
        [HttpPost]
        public JsonResult ValidUsername(string UserName)
        {
            bool userExist = userManagment.UserExist(UserName);
            return Json(!userExist);
        }


        [Authorize(Roles = "Manager")]
        public IActionResult ResetPassword(string userId)
        {
            string newPassword = userManagment.ResetPassword(userId);

            var users = userManagment.GetExistingUsers();
            IList<UserAccountIndexViewModel> usersVM = PrepareUserAccountIndexViewModel();
            foreach (var x in usersVM)
            {
                if (x.Id.Equals(userId))
                {
                    x.NewPassword = newPassword;
                    x.HasResetPassword = true;
                    break;
                }
            }
            return View("Index", usersVM);
        }


        [Authorize(Roles = "Manager")]
        public IActionResult Delete(string userId)
        {
            userManagment.DeactivateUser(userId);
            return View("Index", PrepareUserAccountIndexViewModel());
        }


        [Authorize(Roles = "Manager")]
        public IActionResult Edit(string userId)
        {
            UserAccountEditViewModel vm = userManagment.GetUserDetails(userId);
            return View(vm);
        }


        [Authorize(Roles = "Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserAccountEditViewModel userEditModel)
        {
            if (ModelState.IsValid)
            {
                userManagment.UpdateUser(userEditModel);
                return RedirectToAction("Index");
            }
            return View(userEditModel);
        }



        [Authorize(Roles = "Manager, ConstructionSiteManager")]
        public IActionResult Profile()
        {
            User u = userManagment.GetLoggedUser();

            return View(new UserAccountsProfileViewModel()
            {
                BirthDate = u.DateOfBirth,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName
            });
        }

        [Authorize(Roles = "Manager, ConstructionSiteManager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Profile(UserAccountsProfileViewModel obj)
        {
            if (!string.IsNullOrEmpty(obj.NewPassword) && string.IsNullOrEmpty(obj.OldPassword))
            {
                ModelState.AddModelError(nameof(obj.OldPassword), "Upišite staru lozinku");
                return View(obj);
            }
            bool isSuccess = userManagment.UpdateUserProfile(obj);
            if (!isSuccess)
            {
                ModelState.AddModelError("", "Promjena passworda nije uspjela, pokušajte ponovo");
            }
            return View(obj);
        }


        [Authorize(Roles = "Manager, ConstructionSiteManager")]
        [HttpPost]
        public JsonResult ValidPassword(string oldPassword)
        {
            bool samePassword = userManagment.IsPasswordCorrect(oldPassword);
            return Json(samePassword);
        }


        private IList<UserAccountIndexViewModel> PrepareUserAccountIndexViewModel()
        {
            var users = userManagment.GetExistingUsers();
            IList<UserAccountIndexViewModel> usersVM = new List<UserAccountIndexViewModel>();
            UserAccountIndexViewModel vm;
            foreach (var x in users)
            {
                if (x.IsDeleted)
                    continue;
                vm = new UserAccountIndexViewModel()
                {
                    Id = x.Id,
                    Email = x.Email,
                    FirstNameLastName = x.FirstName + " " + x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    Username = x.UserName,
                    BirthDate = x.DateOfBirth
                };
                usersVM.Add(vm);
            }
            return usersVM;
        }
    }
}