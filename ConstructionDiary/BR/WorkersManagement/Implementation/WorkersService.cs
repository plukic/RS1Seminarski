using ConstructionDiary.BR.ConstructionSites.Interfaces;
using ConstructionDiary.DAL;
using ConstructionDiary.ViewModels.WorkSheet;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstructionDiary.BR.WorkersManagement.Implementation
{
    public class WorkersService: IWorkersService
    {
        private readonly ConstructionCompanyContext _db;
        public WorkersService(ConstructionCompanyContext db)
        {
            _db = db;
        }
        public List<TaskVM> GetTodaysTasks(int? workerId)
        {
            List <TaskVM> tasks = _db.Worksheets.Where(w => w.Date == DateTime.Today).SelectMany(w => w.Tasks)
                .Select(
                t =>
                 new TaskVM()
                    {
                        description = t.Description,
                        id = t.Id,
                        title = t.Title,
                        Workers = t.WorkerTasks.Where(wt => wt.TaskId == t.Id).Select(wt => wt.Worker).ToList()
                 })
                .ToList();
            if (workerId == null)
            {
                return tasks;
            }

            return tasks.Where(t => t.Workers.Exists(w => w.Id == workerId) == true).ToList();
        }
    }
}
