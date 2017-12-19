using ConstructionDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionDiary.BR
{
    public interface IUserManagment
    {
        User LoginUser(UserLoginModel userLoginModel);
        void LogoutUser();
        bool IsUserLogged();
       User GetLoggedUser();
    }

}
