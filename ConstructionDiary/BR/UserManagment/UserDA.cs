using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionDiary.Models;
using Microsoft.AspNetCore.Http;
using ConstructionDiary.DAL;
using Newtonsoft.Json;

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
            var user = session.GetString(KEY_LOGGED_USER_ID);
            return !string.IsNullOrEmpty(user);
        }

        public void LogoutUser()
        {
            session.SetString(KEY_LOGGED_USER_ID, string.Empty);
        }

        public void SaveCurrentUser(User user)
        {
            session.SetString(KEY_LOGGED_USER_ID, JsonConvert.SerializeObject(user));
        }

        public User GetLoggedUser()
        {
            var user = session.GetString(KEY_LOGGED_USER_ID);
            return string.IsNullOrEmpty(user)?null:JsonConvert.DeserializeObject<User>(user);
        }
    }
}
