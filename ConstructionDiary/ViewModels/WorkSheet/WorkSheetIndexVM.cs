using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionDiary.ViewModels.WorkSheet
{
    public class WorkSheetIndexVM
    {
        public int WorkSheetId { get; set; }
        public DateTime WorkSheetDate { get; set; }
        public string ConstructionSiteName { get; set; }
        public bool IsLocked{ get; set; }

    }
}
