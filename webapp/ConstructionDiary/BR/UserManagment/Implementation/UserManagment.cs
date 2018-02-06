using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using ConstructionDiary.BR.UserManagment.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using ConstructionDiary.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using ConstructionDiary.ViewModels.UserAccounts;
using System.Text.RegularExpressions;

namespace ConstructionDiary.BR.UserManagment.Implementation
{
    public class UserManagment : IUserManagment
    {
        private IUserDA userDA;
        private IRoleDA roleDA;
        private readonly IHttpContextAccessor httpContext;
        private readonly UserManager<User> userManager;
        public UserManagment(IUserDA userDA, IRoleDA roleDA, UserManager<User> userManager, IHttpContextAccessor httpContext)
        {
            this.userDA = userDA;
            this.roleDA = roleDA;
            this.userManager = userManager;
            this.httpContext = httpContext;
        }



        public bool CreateUserAsync(RegisterViewModel obj)
        {

            User user = new User
            {
                UserName = obj.UserName,
                Email = obj.Email,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                DateOfBirth = obj.BirthDate,
                NeedToChangePassword = true
            };

            Role r = new Role
            {
                Name = obj.UserSelectedRole
            };

            bool addRole = roleDA.AddRole(r);
            bool addUser = userDA.CreateUserAsync(user, obj.Password);
            if (r.Name.ToLower().Equals("constructionsitemanager"))
                addUser = userDA.CreateConstructionSiteManager(obj);
            bool addRoleToUser = userDA.AddRoleToUser(user, r);

            return addRole && addUser && addRoleToUser;
        }

        public void DeactivateUser(string userId)
        {
            userDA.DeactivateUser(userId);
        }

        public string GenerateUserRandomPassword()
        {
            int passwordLength = 10;
            Regex rgx = new Regex("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{6,12}$");
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            char[] chars = new char[passwordLength];
            Random rd = new Random();

            bool isMatch = false;
            do
            {
                for (int i = 0; i < passwordLength; i++)
                {
                    chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
                }
                isMatch = rgx.IsMatch(new string(chars));
          
            } while (!isMatch);

            return new string(chars);
        }

        public List<User> GetExistingUsers()
        {
            return userDA.GetUsers();
        }

        public User GetLoggedUser()
        {
            string username = httpContext.HttpContext.User.Identity.Name;
            return userDA.FindUser(username);
        }

        public IList<SelectListItem> GetRoles()
        {
            return CreateUserRolesSelectList();
        }

        public UserAccountEditViewModel GetUserDetails(string userId)
        {
            UserAccountEditViewModel vm;
            User u = userManager.FindByIdAsync(userId).Result;
            Role role = roleDA.FindRoleByUserId(userId);
            IList<Role> roles = roleDA.GetRoles();
            IList<SelectListItem> items = new List<SelectListItem>();
            foreach (var x in roles)
            {
                items.Add(new SelectListItem
                {
                    Text = x.Name,
                    Selected = x.Id.Equals(role.Id),
                    Value = x.Name
                });
            }
            vm = new UserAccountEditViewModel
            {
                BirthDate = u.DateOfBirth,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserId = u.Id,
                UserName = u.UserName,
                UserSelectedRole = role.Name,
                Roles = items
            };

            return vm;
        }

        public bool IsPasswordCorrect(string oldPassword)
        {
            User u = GetLoggedUser();
            return userManager.CheckPasswordAsync(u, oldPassword).Result;
        }

        public string ResetPassword(string userId)
        {
            string newPassword = GenerateUserRandomPassword();
            User user = userManager.FindByIdAsync(userId).Result;
            string hashedPass = userManager.PasswordHasher.HashPassword(user, newPassword);

            userDA.UpdateUserPassword(userId, hashedPass);
            return newPassword;
        }

        public void SeedDb()
        {
            var users = GetExistingUsers();
            var roles = roleDA.GetRoles();
            if (users.Count == 0)
            {
                RegisterViewModel rvm = new RegisterViewModel()
                {
                    Email = "admin@admin.ba",
                    FirstName = "Admin",
                    LastName = "Admin",
                    Password = "Password1",
                    UserSelectedRole = "Manager",
                    UserName = "admin"
                };
                CreateUserAsync(rvm);
            }
        }

        public bool ShouldChangePassword()
        {
            User u = GetLoggedUser();
            return u!=null && u.NeedToChangePassword;
        }

        public void UpdateUser(UserAccountEditViewModel userEditModel)
        {
            userDA.UpdateUser(userEditModel);
            roleDA.UpdateRole(userEditModel);
        }

        public bool UpdateUserProfile(UserAccountsProfileViewModel obj)
        {

            userDA.UpdateUserProfile(obj);
            if (!string.IsNullOrEmpty(obj.NewPassword))
            {
                return userDA.ChangePassword(obj);
            }
            return true;

        }

        public bool UserExist(string userName)
        {
            User u = userDA.FindUser(userName);
            return u != null;
        }

        private IList<SelectListItem> CreateUserRolesSelectList()
        {
            IList<Role> roles = roleDA.GetRoles();
            List<SelectListItem> selectListItem = new List<SelectListItem>();
            foreach (Role r in roles)
            {
                selectListItem.Add(new SelectListItem { Text = r.Name, Value = r.NormalizedName });
            }
            return selectListItem;
        }

    }
}
