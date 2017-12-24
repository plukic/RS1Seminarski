using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;

namespace ConstructionDiary.BR.UserManagment.Implementation
{
    public class UserManagment : IUserManagment
    {
        private IUserDA userDA;

        public UserManagment(IUserDA userDA)
        {
            this.userDA = userDA;
        }


        public List<User> GetExistingUsers()
        {
            return userDA.GetUsers();
        }
    }
}
