using DataLayer.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionDiary.ViewModels.WorkSheet
{
    public class TaskVM
    {
        public int id { get; set; }
        [DisplayName("Naziv")]
        public string title { get; set; }

        [DisplayName("Opis")]
        public string description { get; set; }

        [NotMapped]
        public List<int> WorkerIds { get; set; }

        [DisplayName("Radnici")]
        public List<Worker> Workers { get; set; }
    }
}
