using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConstructionDiary.ViewModels.WorkSheet;
using ConstructionDiary.BR.WorkSheetManagement.Interfaces;

namespace ConstructionDiary.Controllers
{
    public class WorkSheetsController : Controller
    {
        IWorkSheetService worksheetService;

        public WorkSheetsController(IWorkSheetService worksheetService)
        {
            this.worksheetService = worksheetService;
        }

        public IActionResult Index()
        {
            List<WorkSheetIndexVM> vm = worksheetService.GetWorkSheetViewModels();
            return View(vm);
        }

        public IActionResult Add()
        {
            WorkSheetAddVM vm = worksheetService.GetWorkSheetAddViewModel();
            return View(vm);

        }
        [HttpPost]
        public IActionResult Add(WorkSheetAddVM vm)
        {
            vm.ConstructionSites = worksheetService.GetWorkSheetAddViewModel().ConstructionSites;
            return View(vm);
        }
    }
}