﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using ConstructionDiary.BR.UserManagment.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using ConstructionDiary.ViewModels;

namespace ConstructionDiary.BR.UserManagment.Implementation
{
    public class UserManagment : IUserManagment
    {
        private IUserDA userDA;
        private IRoleDA roleDA;
        public UserManagment(IUserDA userDA,IRoleDA roleDA)
        {
            this.userDA = userDA;
            this.roleDA = roleDA;
        }

     

        public bool CreateUserAsync(RegisterViewModel obj)
        {
            
            User user = new User
            {
                UserName = obj.UserName,
                Email = obj.Email,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                DateOfBirth = obj.BirthDate
            };

            Role r = new Role
            {
                Name = obj.UserSelectedRole
            };

            return userDA.CreateUserAsync(user, obj.Password) && roleDA.AddRole(r) && userDA.AddRoleToUser(user, r);
        }

        public string GenerateUserRandomPassword()
        {
            int passwordLength = 10;
            int charLength = 6;
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ";
            string allowedNumbers = "0123456789";
            char[] chars = new char[passwordLength];
            Random rd = new Random();

            for (int i = 0; i < charLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }
            for (int i = charLength; i < passwordLength; i++)
            {
                chars[i] = allowedNumbers[rd.Next(0, allowedNumbers.Length)];
            }

            return new string(chars);
        }

        public List<User> GetExistingUsers()
        {
            return userDA.GetUsers();
        }

        public IList<SelectListItem> GetRoles()
        {
            return CreateUserRolesSelectList();
        }

        public bool UserExist(string userName)
        {
            User u = userDA.FindUser(userName);
            return u != null;
        }

        private IList<SelectListItem> CreateUserRolesSelectList()
        {
            IList<Role> roles = roleDA.GetRoles();
            List<SelectListItem> selectListItem = new List<SelectListItem>();
            foreach (Role r in roles){
                selectListItem.Add(new SelectListItem { Text = r.Name, Value = r.NormalizedName });
            }
            return selectListItem;
        }

    }
}
