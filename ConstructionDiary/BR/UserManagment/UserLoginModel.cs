using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionDiary.BR
{
    public class UserLoginModel
    {
        [Required(AllowEmptyStrings =false,ErrorMessage ="Korisnicko ime je obavezno")]
        [StringLength(6,ErrorMessage ="Korisnicko ime mora sadrzavati min 6 karaktera")]
        public string Username { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Lozinka je obavezna")]
        [StringLength(8, ErrorMessage = "Lozinka mora sadrzavati min 8 karaktera")]
        public string Password{ get; set; }
    }
}
