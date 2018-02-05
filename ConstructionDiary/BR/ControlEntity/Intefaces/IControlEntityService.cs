using ConstructionDiary.ViewModels.ControlEntities;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionDiary.BR.ControlEntity.Intefaces
{
    public interface IControlEntityService
    {
        Task<ControlEntry> AddControlEntity(ControlEntitiesAddVM vm, IFormFile file);
        ControlEntitiesIndexVM GetControlEntites(int worksheetId);
        Document GetDocument(int entryId);
    }
}
