using ConstructionDiary.BR.EquipmentManagement.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ConstructionDiary.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService, UserManager<User> userManager)
        {
            _equipmentService = equipmentService;
        }
        // GET: Equipment
        public ActionResult Index()
        {
            List <Equipment> allEquipment = _equipmentService.GetAll().ToList();
            return View(allEquipment);
        }

        // GET: Equipment/Details/5
        public ActionResult Details(int id)
        {
            var equipment = _equipmentService.GetById(id);
            return View(equipment);
        }

        // GET: Equipment/Create
        [Authorize]
        public ActionResult Create()
        {
            var equipment = new Equipment();
            return View(equipment);
        }

        // POST: Equipment/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Equipment equipment)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(equipment);
                }

                if (equipment.Id != 0)
                {
                    _equipmentService.Update(equipment);
                }
                else
                {
                    _equipmentService.Store(equipment);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Equipment/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var equipment = _equipmentService.GetById(id);
            return View("Create", equipment);
        }

        // GET: Equipment/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            var equipment = _equipmentService.GetById(id);
            return View(equipment);
        }

        // POST: Equipment/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _equipmentService.DeleteById(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}