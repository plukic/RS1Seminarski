using Microsoft.AspNetCore.Identity;

namespace DataLayer.Models
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
