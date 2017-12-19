using ConstructionDiary.BR;
using ConstructionDiary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ConstructionDiary.Models.Role;

namespace ConstructionDiary.Helper
{
    public class Authorization : FilterAttribute
    {
        public bool AvailableForManager { get; set; }
        public bool AvailableForConstructionSiteManager { get; set; }
        public bool AvailableForUser { get; set; }

        public Authorization(bool manager, bool constructionSiteManager, bool user)
        {

            AvailableForManager = manager;
            AvailableForConstructionSiteManager = constructionSiteManager;
            AvailableForUser = user;

        }
    override    On  
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            //if (AvailableForUser)
            //    return;
            //User u = Authentication.GetLoggedUser();
            //if (u == null)
            //    context.HttpContext.Response.Redirect("/Home");


            //IList<Role.RoleEnum> availableRoles = new List<Role.RoleEnum>();
            //if (AvailableForConstructionSiteManager)
            //    availableRoles.Add(Role.RoleEnum.ConstructionSiteManager);
            //if (AvailableForManager)
            //    availableRoles.Add(Role.RoleEnum.Manager);

            //foreach (UserRoles r in u.Roles)
            //{
            //    if (availableRoles.Contains(r.Role.UserRole))
            //        return;
            //}
            //context.HttpContext.Response.Redirect("/Home");
        }

    }
}
