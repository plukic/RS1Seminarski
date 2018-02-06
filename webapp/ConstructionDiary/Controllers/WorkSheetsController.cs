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
using ConstructionDiary.ViewModels.ControlEntities;
using ConstructionDiary.DAL;
using Microsoft.EntityFrameworkCore;
using DataLayer.Models;
using System.IO;

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

        ///Worksheets/Complete? worksheetId = @Model.WorkSheetId
        public IActionResult Complete(int worksheetId)
        {
            worksheetService.CompleteWorksheet(worksheetId);
            return RedirectToAction("Add", new { worksheetId = worksheetId });
        }

        ///Worksheets/DeleteControlEntity? entityId = @item.ControleEntitiesId
        public IActionResult DeleteControlEntity(int entityId)
        {
            int worksheetId = worksheetService.RemoveControlEntity(entityId);
            return RedirectToAction("ControlEntities", new { worksheetId = worksheetId });
        }


        //http://localhost:52140/Worksheets/ControlEntities?worksheetId=1
        public IActionResult ControlEntities(int worksheetId)
        {
            ControlEntitiesAddVM vm = new ControlEntitiesAddVM
            {
                DateTime = DateTime.Now,
                Text = "",
                WorksheetId = worksheetId
            };
            return View(vm);
        }
        public async Task<ActionResult> AddControlEntity(ControlEntitiesAddVM vm, IFormFile file)
        {
            await worksheetService.AddControlEntity(vm, file);
            return RedirectToAction("ControlEntities", new { worksheetId = vm.WorksheetId });
        }
  
        public FileResult DownloadEntries(int entryId)
        {
            Document d = worksheetService.GetDocument(entryId);
            byte[] fileBytes = System.IO.File.ReadAllBytes(d.Location);
            return File(fileBytes, d.ContentType,d.FileName);
        }

}
}