using ConstructionDiary.BR.UserManagment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using ConstructionDiary.DAL;
using ConstructionDiary.ViewModels;

namespace ConstructionDiary.BR.UserManagment.Implementation
{
    public class RoleDA : IRoleDA
    {

        private readonly RoleManager<Role> roleManager;
        private readonly ConstructionCompanyContext ctx;
        public RoleDA(RoleManager<Role> roleManager, ConstructionCompanyContext ctx)
        {
            this.roleManager = roleManager;
            this.ctx = ctx;
        }

        public bool AddRole(Role r)
        {
            if (!roleManager.RoleExistsAsync(r.Name).Result)
            {
                IdentityResult roleResult = roleManager.
                CreateAsync(r).Result;
                if (!roleResult.Succeeded)
                {
                    return false;
                }

            }
            return true;
        }

        public Role FindRoleByUserId(string userId)
        {
            var userRole = ctx.UserRoles.Where(x => x.UserId.Equals(userId)).First();
            Role r = ctx.Roles.Where(x => x.Id.Equals(userRole.RoleId)).First();
            return r;
        }

        public IList<Role> GetRoles()
        {
            IList<Role> roles =  ctx.Roles.ToList();

            if (roles.Count == 0)
            {
                AddRole(new Role { Name = "Manager" });
                AddRole(new Role { Name = "ConstructionSiteManager" });

                return ctx.Roles.ToList();
            }
            return roles;
        }

        public void UpdateRole(UserAccountEditViewModel userEditModel)
        {
            var userRole = ctx.UserRoles.Where(x => x.UserId.Equals(userEditModel.UserId)).First();
            Role r = ctx.Roles.Where(x => x.Name.Equals(userEditModel.UserSelectedRole)).First();
            if (userRole.RoleId.Equals(r.Id))
                return;
            ctx.UserRoles.Remove(userRole);
            ctx.SaveChanges();
            ctx.UserRoles.Add(new IdentityUserRole<string>
            {
                RoleId = r.Id,
                UserId = userEditModel.UserId
            });
            ctx.SaveChanges();

        }
    }
}
