using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionDiary.ViewModels
{
    public class UserAccountIndexViewModel
    {
        public string Id { get; set; }
        public string FirstNameLastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public bool HasResetPassword { get; set; }
        public string NewPassword { get; set; }
    }

}
