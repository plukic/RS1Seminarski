using ConstructionDiary.BR.WorkSheetManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionDiary.ViewModels.WorkSheet;
using ConstructionDiary.DAL;

namespace ConstructionDiary.BR.WorkSheetManagement.Implementation
{
    public class WorkSheetService : IWorkSheetService
    {
        ConstructionCompanyContext ctx;

        public WorkSheetService(ConstructionCompanyContext ctx)
        {
            this.ctx = ctx;
        }

        public WorkSheetAddVM GetWorkSheetAddViewModel()
        {
            WorkSheetAddVM vm = new WorkSheetAddVM
            {
                Date = DateTime.Now,
                Remark = "",
                ConstructionSites = ctx.ConstructionSites
                .Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = x.Title, Value = x.Id.ToString() })
                .ToList()
            };
            return vm;
        }

        public List<WorkSheetIndexVM> GetWorkSheetViewModels()
        {
            return ctx.Worksheets.Select(x => new WorkSheetIndexVM {
                 WorkSheetId = x.Id,
                 ConstructionSiteName = x.ConstructionSite.Title,
                 IsLocked = x.IsLocked,
                 WorkSheetDate = x.Date
            }).ToList();
        }
    }
}
