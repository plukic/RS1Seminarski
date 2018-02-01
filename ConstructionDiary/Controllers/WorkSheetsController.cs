using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConstructionDiary.ViewModels.WorkSheet;
using ConstructionDiary.BR.WorkSheetManagement.Interfaces;
using Newtonsoft.Json;

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

        public IActionResult Add(int? worksheetId)
        {
            WorkSheetAddVM vm;
            if (worksheetId == null)
                vm = worksheetService.GetWorkSheetAddViewModel();
            else
            {
                vm = worksheetService.GetWorkSheetEditViewModel(worksheetId.Value);
                vm.WorkSheetId = worksheetId.Value;
                vm.TasksJson = JsonConvert.SerializeObject(vm.Tasks);
                vm.MaterialsJson = JsonConvert.SerializeObject(vm.Materials);
            }
            return View(vm);

        }
        [HttpPost]
        public IActionResult Add(WorkSheetAddVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.ConstructionSites = worksheetService.GetWorkSheetAddViewModel().ConstructionSites;
                vm.TasksJson = JsonConvert.SerializeObject(vm.Tasks);
                vm.MaterialsJson = JsonConvert.SerializeObject(vm.Materials);
                return View(vm);
            }
            worksheetService.AddWorkSheet(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int worksheetId)
        {
            worksheetService.RemoveWorkSheet(worksheetId);
            return RedirectToAction("Index");
        }
    }
}