using ConstructionDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionDiary.BR.UserManagment
{
    public interface IUserManagment
    {
        List<User> GetExistingUsers(); 
    }
}
