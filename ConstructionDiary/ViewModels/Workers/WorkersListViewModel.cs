using System.Collections.Generic;
using System.ComponentModel;

namespace ConstructionDiary.ViewModels
{
    public class WorkerViewModel
    {
        public int Id { get; set; }

        [DisplayName("Ime")]
        public string FirstName { get; set; }

        [DisplayName("Ime")]
        public string LastName { get; set; }


        [DisplayName("Opis posla")]
        public string JobDescription { get; set; }

        [DisplayName("Broj telefona")]
        public string TelephoneNumber { get; set; }

    }
    public class WorkersListViewModel
    {
        public List<WorkerViewModel> Data { get; set; }

    }
}
