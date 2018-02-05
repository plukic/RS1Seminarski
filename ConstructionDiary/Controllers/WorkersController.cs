using ConstructionDiary.DAL;
using ConstructionDiary.ViewModels;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ConstructionDiary.Controllers
{
    public class WorkersController : Controller
    {
        private readonly ConstructionCompanyContext _db;
        public WorkersController(ConstructionCompanyContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            var model = new WorkersListViewModel
            {
                Data = _db.Workers.Select(w => new WorkerViewModel
                {
                    FirstName = w.FirstName,
                    LastName = w.LastName,
                    Id = w.Id,
                    JobDescription = w.JobDescription,
                    TelephoneNumber = w.TelephoneNumber,
                }).ToList()
            };
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateWorkerViewModel model)
        {
            try
            {
                var worker = new Worker
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    JobDescription = model.JobDescription,
                    TelephoneNumber = model.TelephoneNumber,
                };
                _db.Workers.Add(worker);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}