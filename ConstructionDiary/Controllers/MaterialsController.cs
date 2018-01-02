using ConstructionDiary.BR.MaterialsManagement.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionDiary.Controllers
{
    public class MaterialsController : Controller
    {
        private readonly IMaterialsService _materialsService;
        public MaterialsController(IMaterialsService materialsService)
        {
            _materialsService = materialsService;
        }
        // GET: Materials
        public ActionResult Index()
        {
            var materials = _materialsService.GetAll();
            return View(materials);
        }

        // GET: Materials/Details/5
        public ActionResult Details(int id)
        {
            var material = _materialsService.GetById(id);
            return View(material);
        }

        // GET: Materials/Create
        [Authorize]
        public ActionResult Create()
        {
            var material = new Material();
            return View(material);
        }

        // POST: Materials/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Material material)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(material);
                }

                if (material.Id != 0)
                {
                    _materialsService.Update(material);
                }
                else
                {
                    _materialsService.Store(material);
                }


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Materials/Edit/5
        public ActionResult Edit(int id)
        {
            var material = _materialsService.GetById(id);
            return View("Create", material);
        }

        // GET: Materials/Delete/5
        public ActionResult Delete(int id)
        {
            var material = _materialsService.GetById(id);
            return View(material);
        }

        // POST: Materials/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _materialsService.DeleteById(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}