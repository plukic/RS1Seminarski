using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionDiary.Models
{
    public class Role
    {
        public enum RoleEnum
        {
            Manager,
            ConstructionSiteManager,
            DefaultUser
        }
        public int Id { get; set; }
        public string Description { get; set; }
        public RoleEnum UserRole { get; set; }
        public IList<UserRoles> Users { get; set; }
    }
}
