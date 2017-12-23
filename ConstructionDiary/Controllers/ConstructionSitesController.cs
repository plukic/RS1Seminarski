using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionDiary.DAL;
using ConstructionDiary.Models;
using ConstructionDiary.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConstructionDiary.Controllers
{
    public class ConstructionSitesController : Controller
    {
        private IRepository<ConstructionSite> _constructionSitesRepository;
        private IRepository<City> _citiesRepository;
        private UserManager<User> _userManager;
        private ILogger<ConstructionSitesController> _logger;

        public ConstructionSitesController(
            IRepository<ConstructionSite> constructionSitesRepository,
            IRepository<City> citiesRepository,
            ILogger<ConstructionSitesController> logger,
            UserManager<User> userManager)
        {
            _constructionSitesRepository = constructionSitesRepository;
            _citiesRepository = citiesRepository;
            _userManager = userManager;
            _logger = logger;
        }
        // GET: ConstructionSites
        public ActionResult Index()
        {
            List<ConstructionSite> constructionSites = _constructionSitesRepository.List().ToList();
            return View(constructionSites);
        }

        // GET: ConstructionSites/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ConstructionSites/Create
        public ActionResult Create()
        {
            List<City> cities = _citiesRepository.List().ToList();
            ConstructionSite constructionSite = new ConstructionSite();
            var viewModel = new CreateConstructionSiteViewModel()
            {
                constructionSite = constructionSite,
                cities = cities,
            };
            return View(viewModel);
        }

        // POST: ConstructionSites/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ConstructionSite constructionSite)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                var user = await _userManager.GetUserAsync(HttpContext.User);
                constructionSite.UserId = user.Id;
                constructionSite.ContractId = 3;
                constructionSite.LocationId = 1;

                _constructionSitesRepository.Add(constructionSite);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                _logger.LogError("Error creating constriction site", e);
                return RedirectToAction("Create");
            }
        }

        // GET: ConstructionSites/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ConstructionSites/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ConstructionSites/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ConstructionSites/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}