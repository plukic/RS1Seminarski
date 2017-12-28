using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using ConstructionDiary.ViewModels;

namespace ConstructionDiary.BR.UserManagment
{
    public interface IUserManagment
    {
        List<User> GetExistingUsers();
        bool CreateUserAsync(RegisterViewModel obj);
        IList<SelectListItem> GetRoles();
        string GenerateUserRandomPassword();
        bool UserExist(string userName);
        string ResetPassword(string userId);
        void DeactivateUser(string userId);
    }
}
