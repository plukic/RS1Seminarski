using ConstructionDiary.BR;
using ConstructionDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionDiary.Helper
{
    public class Authentication
    {
        static IUserManagment user;
        public Authentication(IUserManagment userManagment)
        {
            user = userManagment;
        }
        internal static User GetLoggedUser()
        {
            return user.GetLoggedUser();
        }
    }
}
