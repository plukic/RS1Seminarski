using ConstructionDiary.ViewModels.WorkSheet;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionDiary.BR.WorkSheetManagement.Interfaces
{
    public interface IWorkSheetService
    {
        List<WorkSheetIndexVM> GetWorkSheetViewModels();
        WorkSheetAddVM GetWorkSheetAddViewModel();
    }
}
