using ConstructionDiary.BR.ControlEntity.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionDiary.ViewModels.ControlEntities;
using Microsoft.AspNetCore.Http;
using ConstructionDiary.BR.Documents.Interfaces;
using ConstructionDiary.DAL;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace ConstructionDiary.BR.ControlEntity.Implementation
{
    public class ControlEntityService : IControlEntityService
    {
        IDocumentsService documentService;
        ConstructionCompanyContext ctx;

        public ControlEntityService(IDocumentsService documentService, ConstructionCompanyContext ctx) 
        {
            this.ctx = ctx;
            this.documentService = documentService;
        }

        public async Task<ControlEntry> AddControlEntity(ControlEntitiesAddVM vm, IFormFile file)
        {
            Document document = await documentService.Store(file, "opis");

            var entry = new ControlEntry
            {
                Date = vm.DateTime,
                Document = document,
                Text = vm.Text,
                WorksheetId = vm.WorksheetId
            };
            ctx.ControlEntries.Add(entry);
            ctx.SaveChanges();
            return entry;
        }

        public ControlEntitiesIndexVM GetControlEntites(int worksheetId)
        {
            var ws = ctx.Worksheets.Where(x => x.Id == worksheetId).Include(x => x.ConstructionSite).First();

            ControlEntitiesIndexVM vm = new ControlEntitiesIndexVM
            {
                WorksheetId = ws.Id,
                WorksheetDescription = ws.ConstructionSite.Title + " - " + ws.Date.ToShortDateString()
            };
            vm.Rows = ctx.ControlEntries.Where(x => x.WorksheetId == worksheetId)
                .Select(x => new ControlEntitiesIndexVM.Row
                {
                    ControleEntitiesId = x.Id,
                    Date = x.Date.ToShortDateString(),
                    Text = x.Text,
                    DocumentName = x.Document.FileName,
                    DocumentLink = x.Document.Location
                })
                .ToList();
            return vm;
        }

        public Document GetDocument(int entryId)
        {
            var ce = ctx.ControlEntries.Where(x => x.Id == entryId).First();
            return ctx.Documents.Where(x => x.Id == ce.DocumentId).First();
        }
    }
}
