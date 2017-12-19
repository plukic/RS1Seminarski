using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionDiary.Models;
using Microsoft.AspNetCore.Http;
using ConstructionDiary.DAL;

namespace ConstructionDiary.BR
{
    public class UserDA : IUserDA
    {
        private IHttpContextAccessor httpContextAccessor;
        private ISession session => httpContextAccessor.HttpContext.Session;
        private ConstructionCompanyContext ctx;
        private string KEY_LOGGED_USER_ID = "KEY_LOGGED_USER_ID";

        public UserDA(ConstructionCompanyContext ctx, IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.ctx = ctx;
        }
        public User FindUser(UserLoginModel userLoginModel)
        {
            var users = ctx.Users;
            return users.Where(x => x.Username.Equals(userLoginModel.Username)).FirstOrDefault();
        }

        public bool IsUserLogged()
        {
            return session.GetInt32(KEY_LOGGED_USER_ID) !=0;
        }

        public void LogoutUser()
        {
            session.SetInt32(KEY_LOGGED_USER_ID, 0);
        }

        public void SaveCurrentUser(User user)
        {
            session.SetInt32(KEY_LOGGED_USER_ID, user.Id);
        }
    }
}
