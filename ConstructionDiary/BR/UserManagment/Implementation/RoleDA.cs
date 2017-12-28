using ConstructionDiary.BR.UserManagment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using Microsoft.AspNetCore.Identity;

namespace ConstructionDiary.BR.UserManagment.Implementation
{
    public class RoleDA : IRoleDA
    {

        private readonly RoleManager<Role> roleManager;

        public RoleDA(RoleManager<Role> roleManager)
        {
            this.roleManager = roleManager;
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

      

        public IList<Role> GetRoles()
        {
            IList<Role> roles = new List<Role>
            {
                new Role{Name="Manager"},new Role{Name="ConstructionSiteManager"}
            };
            
            return roles;
        }
    }
}
