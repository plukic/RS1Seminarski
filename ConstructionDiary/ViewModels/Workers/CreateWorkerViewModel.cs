using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConstructionDiary.ViewModels
{
    public class CreateWorkerViewModel
    {
        public int? Id{ get; set; }
        [Required]
        [DisplayName("Ime")]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Prezime")]
        [MinLength(3)]
        public string LastName { get; set; }


        [Required]
        [DisplayName("Opis posla")]
        [MinLength(3)]
        public string JobDescription { get; set; }

        [Required]
        [DisplayName("Broj telefona")]
        [DataType(DataType.PhoneNumber)]
        public string TelephoneNumber { get; set; }

    }
}
