using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionDiary.Controllers
{
    public class WorksSheetAjaxController : Controller
    {
        public IActionResult IndexTasks()
        {

            return PartialView();
        }

        public IActionResult AddTask()
        {
            return PartialView();
        }

        public IActionResult IndexEquipment()
        {
            return PartialView();
        }
    }
}