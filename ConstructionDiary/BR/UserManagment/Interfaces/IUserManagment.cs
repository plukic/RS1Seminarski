using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;

namespace ConstructionDiary.BR.UserManagment
{
    public interface IUserManagment
    {
        List<User> GetExistingUsers(); 
    }
}
