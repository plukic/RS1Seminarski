using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionDiary.DAL;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace ConstructionDiary.BR.UserManagment.Implementation
{
    public class UserDA : IUserDA
    {
        ConstructionCompanyContext ctx;

        public UserDA(ConstructionCompanyContext ctx)
        {
            this.ctx = ctx;
        }

        public List<User> GetUsers()
        {
            return ctx.Users.ToList();
        }
    }
}
