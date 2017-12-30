using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionDiary.ViewModels;
using ConstructionDiary.ViewModels.UserAccounts;
using DataLayer.Models;

namespace ConstructionDiary.BR.UserManagment
{
    public interface IUserDA
    {
        List<User> GetUsers();
        bool CreateUserAsync(User user,string password);
        bool AddRoleToUser(User user, Role r);
        User FindUser(string userName);
        void UpdateUserPassword(string userId, string hashedPass);
        void DeactivateUser(string userId);
        void UpdateUser(UserAccountEditViewModel userEditModel);
        void UpdateUserProfile(UserAccountsProfileViewModel obj);
        bool CreateConstructionSiteManager(RegisterViewModel obj);
        bool ChangePassword(UserAccountsProfileViewModel obj);
    }
}
