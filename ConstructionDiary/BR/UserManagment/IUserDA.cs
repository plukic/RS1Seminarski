using ConstructionDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionDiary.BR
{
    public interface IUserDA
    {
        User FindUser(UserLoginModel userLoginModel);
        void SaveCurrentUser(User user);
        void LogoutUser();
        bool IsUserLogged();
        User GetLoggedUser();
    }
}
