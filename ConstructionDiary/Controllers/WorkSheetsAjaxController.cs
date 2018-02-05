using ConstructionDiary.DAL;
using ConstructionDiary.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace ConstructionDiary.Controllers
{
    [Authorize(Roles = "ConstructionSiteManager")]
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
            ViewData["Workers"] = ctx.Workers.Select(u => new SelectListItem {Value = u.Id.ToString(), Text = u.FullName}).ToList();
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
                    Text = x.Name + " - " + x.Unit.ToString(),
                    Value = x.Id.ToString()
                })
                .ToList()
            };
            vm.MaterialId = materialId ?? 0;
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