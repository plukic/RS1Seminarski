using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionDiary.Controllers
{
    public class WorkSheetsAjaxController : Controller
    {
        public IActionResult IndexTasks()
        {
            return PartialView();
        }

        public IActionResult AddTask(int? taskId)
        {
            ViewData["taskId"] = taskId;
            return PartialView();
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