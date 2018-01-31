using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionDiary.ViewModels.WorkSheet
{
    public class WorkSheetAddVM
    {
        public int ConstructionSiteId { get; set; }
        public List<SelectListItem> ConstructionSites { get; set; }
        public DateTime Date { get; set; }
        public string Remark { get; set; }
        public List<TaskVM> Tasks { get; set; }
        public List<MaterialsVM> Materials { get; set; }

    }
}
