using ConstructionDiary.BR.WorkSheetManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionDiary.ViewModels.WorkSheet;
using ConstructionDiary.DAL;
using DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using ConstructionDiary.BR.UserManagment;
using Microsoft.EntityFrameworkCore;

namespace ConstructionDiary.BR.WorkSheetManagement.Implementation
{
    public class WorkSheetService : IWorkSheetService
    {
        ConstructionCompanyContext ctx;
        IUserManagment userManagment;
        public WorkSheetService(ConstructionCompanyContext ctx, IUserManagment userManagment)
        {
            this.userManagment = userManagment;
            this.ctx = ctx;
        }

        public void AddWorkSheet(WorkSheetAddVM vm)
        {
            User u =userManagment.GetLoggedUser();
            var manager  = ctx.ConstructionSiteManagers.Where(x => x.UserId == u.Id).First();
            var constructionSite  = ctx.ConstructionSites.Where(x => x.Id== vm.ConstructionSiteId).First();
            var worksheet = ctx.Worksheets.Where(x => x.Id == vm.WorkSheetId).FirstOrDefault();

            if (worksheet != null)
            {
                UpdateWorkSheet(manager, constructionSite, worksheet, vm);
            }
            else
            {
                AddWorkSheet(manager, vm, constructionSite);
            }

            ctx.SaveChanges();

        }

        private void AddWorkSheet(ConstructionSiteManager manager, WorkSheetAddVM vm, ConstructionSite constructionSite)
        {
            Worksheet ws = new Worksheet
            {
                Date = vm.Date,
                IsLocked = vm.IsLocked,
                WeatherConditions = vm.WeatherConditions,
                GetConstructionSiteManager = manager,
                ConstructionSite = constructionSite,
                Remarks = vm.Remark
            };
            ctx.Worksheets.Add(ws);

            if (vm.Tasks != null)
            {
                foreach (var item in vm.Tasks)
                {
                    ctx.Tasks.Add(new DataLayer.Models.Task
                    {
                        Description = item.description,
                        Title = item.title,
                        Worksheet = ws
                    });
                }
            }
            if (vm.Materials != null)
            {
                foreach (var item in vm.Materials)
                {
                    var material = ctx.Material.Where(x => x.Id == item.id).First();
                    material.Amount -= item.amount;

                    ctx.WorksheetMaterial.Add(new DataLayer.Models.WorksheetMaterial
                    {
                        Amount = item.amount,
                        MaterialId = item.id,
                        Worksheet = ws
                    });
                }
            }
        }

        private void UpdateWorkSheet(ConstructionSiteManager manager, ConstructionSite constructionSite, Worksheet worksheet, WorkSheetAddVM vm)
        {
            worksheet.Date = vm.Date;
            worksheet.IsLocked = vm.IsLocked;
            worksheet.WeatherConditions = vm.WeatherConditions;
            worksheet.Remarks = vm.Remark;
            //update and delete materials
            #region materials
            var newMaterials = vm.Materials;
            var oldMaterials = ctx.WorksheetMaterial.Include(x=>x.Material).Where(x => x.WorksheetId == worksheet.Id).ToList();

            var materialsToRemove = oldMaterials.Where(x => IsRemovedFromList(x, newMaterials)).ToList();
            var materialsToUpdate = oldMaterials.Where(x => !IsRemovedFromList(x, newMaterials)).ToList();

            //add materials to stock
            foreach (var item in materialsToRemove)
            {
                item.Material.Amount += item.Amount;
            }
            ctx.WorksheetMaterial.RemoveRange(materialsToRemove);
            foreach (var item in materialsToUpdate)
            {
                var updatedItem = newMaterials.Where(x => x.id == item.MaterialId).First();
                item.Amount = updatedItem.amount;
            }
            #endregion

            //update and delete takss
            #region tasks
            var newTasks = vm.Tasks;
            var oldTasks = ctx.Tasks.Where(x => x.WorksheetId == worksheet.Id).ToList();

            var tasksToRemove = oldTasks.Where(x => IsRemovedFromList(x, newTasks)).ToList();
            var tasksToUpdate = oldTasks.Where(x => !IsRemovedFromList(x,newTasks)).ToList();

            ctx.Tasks.RemoveRange(tasksToRemove);
            foreach (var item in tasksToUpdate)
            {
                var updatedItem = newTasks.Where(x => x.id == item.Id).First();
                item.Title= updatedItem.title;
                item.Description= updatedItem.description;
            }
            #endregion


            //add materials
            if (newMaterials != null)
            {
                var materialsToAdd = newMaterials.Where(x => !IsInList(x, oldMaterials)).Select(x => new WorksheetMaterial
                {
                    Amount = x.amount,
                    MaterialId = x.id,
                    Worksheet = worksheet
                }).ToList();
                //remove materials from stock
                foreach (var item in materialsToAdd)
                {
                    ctx.Material.Where(x => x.Id == item.MaterialId).First().Amount-=item.Amount;
                }
                ctx.WorksheetMaterial.AddRange(materialsToAdd);
            }
            //add tasks
            if (newTasks != null)
            {
                var tasksToAdd= newTasks.Where(x => !IsInList(x, oldTasks)).Select(x => new DataLayer.Models.Task
                {
                    Description = x.description,
                    Title = x.title,
                    Worksheet = worksheet
                }).ToList();

                ctx.Tasks.AddRange(tasksToAdd);
            }
        }

        private bool IsInList(TaskVM x, List<DataLayer.Models.Task> oldTasks)
        {
            foreach (var item in oldTasks)
            {
                if (x.id == item.Id)
                    return true;
            }
            return false;
        }

        private bool IsInList(MaterialsVM x, List<WorksheetMaterial> oldMaterials)
        {
            foreach (var item in oldMaterials)
            {
                if (x.id == item.MaterialId)
                    return true;
            }
            return false;
        }

        private bool IsRemovedFromList(DataLayer.Models.Task  x, List<TaskVM> newTasks)
        {
            if (newTasks == null || newTasks.Count == 0)
                return true;

            foreach (var item in newTasks)
            {
                if (item.id == x.Id)
                    return false;
            }
            return true;
        }

        private bool IsRemovedFromList(WorksheetMaterial x, List<MaterialsVM> newMaterials)
        {
            if (newMaterials == null || newMaterials.Count == 0)
                return true;

            foreach (var item in newMaterials)
            {
                if (item.id == x.MaterialId)
                    return false;
            }
            return true;
        }

        public WorkSheetAddVM GetWorkSheetAddViewModel()
        {
            WorkSheetAddVM vm = new WorkSheetAddVM
            {
                Date = DateTime.Now,
                Remark = "",
                ConstructionSites = ctx.ConstructionSites
                .Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = x.Title, Value = x.Id.ToString() })
                .ToList()
            };
            return vm;
        }

        public WorkSheetAddVM GetWorkSheetEditViewModel(int worksheetId)
        {
            Worksheet ws = ctx.Worksheets.Include(x=>x.ConstructionSite).Where(x => x.Id == worksheetId).First();

            WorkSheetAddVM vm = new WorkSheetAddVM
            {
                ConstructionSiteId = ws.ConstructionSite.Id,
                Date = ws.Date,
                IsLocked = ws.IsLocked,
                WeatherConditions = ws.WeatherConditions,
                WorkSheetId = ws.Id,
                Remark = ws.Remarks,
                ConstructionSites = ctx.ConstructionSites
                .Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = x.Title, Value = x.Id.ToString() })
                .ToList()
            };

            foreach (var item in vm.ConstructionSites)
            {
                item.Selected = item.Value.Equals(ws.ConstructionSite.Id.ToString());
            }

            vm.Tasks = ctx.Tasks.Where(x => x.WorksheetId == ws.Id)
                .Select(x=>new TaskVM {description = x.Description,id = x.Id,title = x.Title })
                .ToList();
            vm.Materials = ctx.WorksheetMaterial.Where(x => x.WorksheetId == ws.Id)
                .Select(x=>new MaterialsVM { amount = x.Amount,id = x.MaterialId,name=x.Material.Name + " - " + x.Material.Unit.ToString()} )
                .ToList();
            return vm;
        }

    

        public List<WorkSheetIndexVM> GetWorkSheetViewModels()
        {
            return ctx.Worksheets.Select(x => new WorkSheetIndexVM {
                 WorkSheetId = x.Id,
                 ConstructionSiteName = x.ConstructionSite.Title,
                 IsLocked = x.IsLocked,
                 WorkSheetDate = x.Date
            }).ToList();
        }

        public void RemoveWorkSheet(int worksheetId)
        {
            ctx.Worksheets.Remove(ctx.Worksheets.Where(x => x.Id == worksheetId).First());
            ctx.SaveChanges();
        }
    }
}
