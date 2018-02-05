using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConstructionDiary.ViewModels.WorkSheet;
using ConstructionDiary.BR.WorkSheetManagement.Interfaces;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace ConstructionDiary.Controllers
{
    [Authorize(Roles = "ConstructionSiteManager")]
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
        public IActionResult Add(WorkSheetAddVM model)
        { 
            if (!ModelState.IsValid)
            {
                model.ConstructionSites = worksheetService.GetWorkSheetAddViewModel().ConstructionSites;
                model.TasksJson = JsonConvert.SerializeObject(model.Tasks);
                model.MaterialsJson = JsonConvert.SerializeObject(model.Materials);
                return View(model);
            }
            worksheetService.AddWorkSheet(model);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int worksheetId)
        {
            worksheetService.RemoveWorkSheet(worksheetId);
            return RedirectToAction("Index");
        }
    }
}