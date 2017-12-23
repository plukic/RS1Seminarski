using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionDiary.BR.UserManagment;
using ConstructionDiary.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
                    Email = x.Email,
                    FirstNameLastName = x.FirstName + " " +x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    Username = x.UserName
                });
            }

            return View(usersVM);
        }
    }
}