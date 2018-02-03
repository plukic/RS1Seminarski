using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionDiary.ViewModels
{
    public class UserAccountEditViewModel
    {
        public string UserId { get; set; }
        [DisplayName("Korisničko ime")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Ime")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Prezime")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Datum rođenja")]
        public DateTime BirthDate { get; set; }

        public IList<SelectListItem> Roles { get; set; }
        [Required]
        [DisplayName("Korisnička rola")]
        public string UserSelectedRole { get; set; }

    }
}
