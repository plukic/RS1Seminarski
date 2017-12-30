using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionDiary.ViewModels.UserAccounts
{
    public class UserAccountsProfileViewModel 
    {

        [ReadOnly(true)]
        [Required]
        public string UserName { get; set; }
    
     
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{6,12}$", ErrorMessage = "Lozinka mora biti dužine 6-12 karaktera te sadržavati mala i velika slova kao i brojeve")]
        [Remote("ValidPassword", "UserAccounts", HttpMethod = "POST", ErrorMessage = "Lozinka nije ispravna")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{6,12}$", ErrorMessage = "Lozinka mora biti dužine 6-12 karaktera te sadržavati mala i velika slova kao i brojeve")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Compare(nameof(NewPassword), ErrorMessage = "Lozinke se ne podudaraju")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


    }
}
