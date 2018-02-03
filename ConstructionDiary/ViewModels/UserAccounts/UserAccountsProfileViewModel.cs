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
        [DisplayName("Korisničko ime")]
        public string UserName { get; set; }
    
        [Required]
        [DisplayName("Ime")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Prezime")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Datum rođenja")]
        public DateTime BirthDate { get; set; }

        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{6,12}$", ErrorMessage = "Lozinka mora biti dužine 6-12 karaktera te sadržavati mala i velika slova kao i brojeve")]
        [Remote("ValidPassword", "UserAccounts", HttpMethod = "POST", ErrorMessage = "Lozinka nije ispravna")]
        [DataType(DataType.Password)]
        [DisplayName("Stara lozinka")]
        public string OldPassword { get; set; }

        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{6,12}$", ErrorMessage = "Lozinka mora biti dužine 6-12 karaktera te sadržavati mala i velika slova kao i brojeve")]
        [DataType(DataType.Password)]
        [DisplayName("Nova lozinka")]
        public string NewPassword { get; set; }
        [Compare(nameof(NewPassword), ErrorMessage = "Lozinke se ne podudaraju")]
        [DataType(DataType.Password)]
        [DisplayName("Ponovite lozinku")]
        public string ConfirmPassword { get; set; }


    }
}
