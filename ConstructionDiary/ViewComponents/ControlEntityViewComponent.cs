using ConstructionDiary.BR.ControlEntity.Intefaces;
using ConstructionDiary.ViewModels.ControlEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionDiary.ViewComponents
{
    public class ControlEntity : ViewComponent
    {
        IControlEntityService controlEntityService;

        public ControlEntity(IControlEntityService controlEntityService)
        {
            this.controlEntityService = controlEntityService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int worksheetId)
        {
            ControlEntitiesIndexVM vm = controlEntityService.GetControlEntites(worksheetId);
            return View("Default", vm);
        }
    }
       
}
