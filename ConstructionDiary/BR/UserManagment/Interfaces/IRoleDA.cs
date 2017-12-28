using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;

namespace ConstructionDiary.BR.UserManagment.Interfaces
{
    public interface IRoleDA
    {
        IList<Role> GetRoles();
        bool AddRole(Role r);
    
    }
}
