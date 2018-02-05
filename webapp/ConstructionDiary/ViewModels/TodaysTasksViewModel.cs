using ConstructionDiary.ViewModels.WorkSheet;
using System.Collections.Generic;

namespace ConstructionDiary.ViewModels
{
    public class TodaysTasksViewModel
    {
        public List<TaskVM> Tasks { get; set; }
        public int? SelectedWorkerId { get; set; }
    }
}
