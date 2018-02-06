using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionDiary.DAL;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ConstructionDiary.ViewModels;
using ConstructionDiary.ViewModels.UserAccounts;

namespace ConstructionDiary.BR.UserManagment.Implementation
{
    public class UserDA : IUserDA
    {
        ConstructionCompanyContext ctx;
        private readonly UserManager<User> userManager;

        public UserDA(ConstructionCompanyContext ctx, UserManager<User> userManager)
        {
            this.ctx = ctx;
            this.userManager = userManager;
        }

        public bool AddRoleToUser(User user, Role r)
        {
            userManager.AddToRoleAsync(user, r.Name).Wait();
            return true;
        }

        public bool ChangePassword(UserAccountsProfileViewModel obj)
        {
            var username = obj.UserName;
            User u = ctx.Users.Where(x => x.UserName.Equals(obj.UserName)).First();

            bool result = userManager.ChangePasswordAsync(u, obj.OldPassword, obj.NewPassword).Result.Succeeded;
            u.NeedToChangePassword = !result;
            ctx.SaveChanges();
            return result;
        }

        public bool CreateConstructionSiteManager(RegisterViewModel obj)
        {
            User u = ctx.Users.Where(x => x.UserName.Equals(obj.UserName)).First();

            ConstructionSiteManager csm = new ConstructionSiteManager
            {
                User = u,
                UserId = u.Id
            };
            ctx.ConstructionSiteManagers.Add(csm);
            ctx.SaveChanges();
            return true;

        }

        public bool CreateUserAsync(User user, string password)
        {

            IdentityResult result = userManager.CreateAsync
            (user, password).Result;

            return result.Succeeded;
        }

        public void DeactivateUser(string userId)
        {
            User u = ctx.Users.Where(x => x.Id.Equals(userId)).FirstOrDefault();
            u.IsDeleted = true;
            ctx.SaveChanges();
        }

        public User FindUser(string userName)
        {
            return ctx.Users.Where(x => x.UserName.Equals(userName)).FirstOrDefault();

        }



        public List<User> GetUsers()
        {
            return ctx.Users.ToList();
        }

        public void UpdateUser(UserAccountEditViewModel userEditModel)
        {
            User u = ctx.Users.Where(x => x.Id.Equals(userEditModel.UserId)).FirstOrDefault();
            u.Email = userEditModel.Email;
            u.FirstName = userEditModel.FirstName;
            u.LastName = userEditModel.LastName;
            u.DateOfBirth = userEditModel.BirthDate;
            ctx.SaveChanges();

        }

        public void UpdateUserPassword(string userId, string hashedPass)
        {
            User u = ctx.Users.Where(x => x.Id.Equals(userId)).First();
            u.NeedToChangePassword = true;
            u.PasswordHash = hashedPass;
            ctx.SaveChanges();
        }

        public void UpdateUserProfile(UserAccountsProfileViewModel obj)
        {
            User u = ctx.Users.Where(x => x.UserName.Equals(obj.UserName)).FirstOrDefault();
            u.Email = obj.Email;
            u.FirstName = obj.FirstName;
            u.LastName = obj.LastName;
            u.DateOfBirth =obj.BirthDate;
            ctx.SaveChanges();
        }
    }
}
