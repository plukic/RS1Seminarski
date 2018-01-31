using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConstructionDiary.DAL;
using ConstructionDiary.ViewModels;

namespace ConstructionDiary.Controllers
{
    public class WorkSheetsAjaxController : Controller
    {
        ConstructionCompanyContext ctx;

        public WorkSheetsAjaxController(ConstructionCompanyContext ctx)
        {
            this.ctx = ctx;
        }

        public IActionResult IndexTasks()
        {
            return PartialView();
        }

        public IActionResult AddTask(int? taskId)
        {
            ViewData["taskId"] = taskId;
            return PartialView();
        }
        public IActionResult IndexMaterials()
        {
            return PartialView();
        }

        public IActionResult AddMaterial(int? materialId)
        {
            AddMaterialVM vm = new AddMaterialVM
            {
                Materials = ctx.Material.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = x.Name + " - " + x.Unit,
                    Value = x.Id.ToString()
                })
                .ToList()
            };
            if (materialId != null)
            {
                foreach (var item in vm.Materials)
                {
                    item.Selected = item.Value.Equals(materialId);
                }
            }
            return PartialView(vm);
        }

        public IActionResult IndexEquipment()
        {

            return PartialView();
        }

        public IActionResult AddEquipment()
        {
            return PartialView();
        }
    }
}