using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionDiary.BR
{
    public class UserLoginViewModel
    {
        /*
         * the match must be alphanumeric with at least one number, one letter, and be between 6-15 character in length. 
         */
        [Required(AllowEmptyStrings = false)]
        public string Username { get; set; }

        /*
         * the match must be alphanumeric with at least one number, one letter, and be between 6-15 character in length. 
         */
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
