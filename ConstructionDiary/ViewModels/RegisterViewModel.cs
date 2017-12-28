using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConstructionDiary.ViewModels
{
    public class RegisterViewModel
    {
        [Remote("ValidUsername", "UserAccounts", HttpMethod = "POST", ErrorMessage = "Korisničko ime se već koristi")]
        [Required]
        public string UserName { get; set; }
        [Required]
        [RegularExpression( "^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{6,12}$",ErrorMessage = "Lozinka mora biti dužine 6-12 karaktera te sadržavati mala i velika slova kao i brojeve")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
   
        public IList<SelectListItem> Roles  { get; set; }
        [Required]
        public string UserSelectedRole { get; set; }

    }
}
