using ConstructionDiary.ViewModels.WorkSheet;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionDiary.ViewModels.ControlEntities;
using Microsoft.AspNetCore.Http;

namespace ConstructionDiary.BR.WorkSheetManagement.Interfaces
{
    public interface IWorkSheetService
    {
        List<WorkSheetIndexVM> GetWorkSheetViewModels();
        WorkSheetAddVM GetWorkSheetAddViewModel();
        void AddWorkSheet(WorkSheetAddVM vm);
        WorkSheetAddVM GetWorkSheetEditViewModel(int worksheetId);
        void RemoveWorkSheet(int worksheetId);
        void CompleteWorksheet(int worksheetId);

        Task<ControlEntry> AddControlEntity(ControlEntitiesAddVM vm, IFormFile file);
        int RemoveControlEntity(int entityId);
        Document GetDocument(int entryId);
    }
}
