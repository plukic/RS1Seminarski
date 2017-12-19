using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionDiary.Models;

namespace ConstructionDiary.BR
{
    public class UserManagment : IUserManagment
    {
        IUserDA userDA;
        public UserManagment(IUserDA _userDa)
        {
            this.userDA = _userDa;
        }

        public User GetLoggedUser()
        {
            return userDA.GetLoggedUser();
        }

        public bool IsUserLogged()
        {
            return userDA.IsUserLogged();
        }

        public User LoginUser(UserLoginModel userLoginModel)
        {
            if (string.IsNullOrEmpty(userLoginModel.Username) || string.IsNullOrEmpty(userLoginModel.Username))
                throw new Exception("Invalid login parameters");

            var user = userDA.FindUser(userLoginModel);
            if (user == null)
                return null;

            var salt = user.Salt;
            var hash = user.Hash;
            var loginHash = PasswordHelper.CreateHash(userLoginModel.Password, salt);

            if (loginHash.Equals(hash))
            {
                userDA.SaveCurrentUser(user);
                return user;
            }
            return null;
        }
        

        public void LogoutUser()
        {
           userDA.LogoutUser();
        }
    }
}
