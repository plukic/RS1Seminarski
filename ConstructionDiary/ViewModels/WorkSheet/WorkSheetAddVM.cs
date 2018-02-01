using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionDiary.ViewModels.WorkSheet
{
    public class WorkSheetAddVM
    {
        public int WorkSheetId { get; set; }
        public int ConstructionSiteId { get; set; }
        public List<SelectListItem> ConstructionSites { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string Remark { get; set; }
        public string TasksJson { get; set; }
        public string MaterialsJson { get; set; }
        public List<TaskVM> Tasks { get; set; }
        public List<MaterialsVM> Materials { get; set; }
        public bool IsLocked { get; set; }
        public string WeatherConditions { get; set; }
    }
}
