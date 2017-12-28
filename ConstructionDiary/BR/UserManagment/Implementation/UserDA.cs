using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionDiary.DAL;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

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

        public bool CreateUserAsync(User user, string password)
        {

            IdentityResult result = userManager.CreateAsync
            (user, password).Result;

            return result.Succeeded;
        }

        public User FindUser(string userName)
        {
            return ctx.Users.Where(x=>x.UserName.Equals(userName)).FirstOrDefault();

        }

        public List<User> GetUsers()
        {
            return ctx.Users.ToList();
        }
    }
}
