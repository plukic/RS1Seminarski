using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionDiary.ViewModels.WorkSheet
{
    public class WorkSheetIndexVM
    {
        public int WorkSheetId { get; set; }
        [DisplayName("Datum radnog lista")]
        public DateTime WorkSheetDate { get; set; }
        [DisplayName("Gradilište")]
        public string ConstructionSiteName { get; set; }
        [DisplayName("Stanje")]
        public bool IsLocked{ get; set; }

    }
}
