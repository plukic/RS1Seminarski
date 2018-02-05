using ConstructionDiary.ViewModels.WorkSheet;
using System.Collections.Generic;

namespace ConstructionDiary.BR.ConstructionSites.Interfaces
{
    public interface IWorkersService
    {
        List<TaskVM> GetTodaysTasks(int? workerId);
    }
}
