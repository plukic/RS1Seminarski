using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionDiary.Models
{
    public class Role : IdentityRole
    {
        public enum RoleEnum
        {
            Manager,
            ConstructionSiteManager,
            DefaultUser
        }
        public string Description { get; set; }
        public RoleEnum UserRole { get; set; }
    }
}
