using ConstructionDiary.BR.ConstructionSites.Interfaces;
using ConstructionDiary.DAL;
using ConstructionDiary.ViewModels;
using DataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionDiary.DAL.Specs;

namespace ConstructionDiary.Controllers
{
    public class ConstructionSitesController : Controller
    {
        private readonly IRepository<City> _citiesRepository;
        private readonly ILogger<ConstructionSitesController> _logger;
        private readonly IConstructionSitesService _constructionSitesService;
        private readonly UserManager<User> _userManager;

        public ConstructionSitesController(
            IRepository<City> citiesRepository,
            IRepository<Contract> contractsRepository,
            ILogger<ConstructionSitesController> logger,
            IConstructionSitesService constructionSitesService,
            UserManager<User> userManager)
        {
            _citiesRepository = citiesRepository;
            _logger = logger;
            _constructionSitesService = constructionSitesService;
            _userManager = userManager;
        }
        // GET: ConstructionSites
        public ActionResult Index(OpenStatus? openStatus, City selectedCity)
        {
            ISpecification <ConstructionSite> specification = new ConstructionSitesFilters(
                openStatus,
                selectedCity.Id == 0 ? null : selectedCity
            );
            List<ConstructionSite> constructionSites = _constructionSitesService.GetAll(specification);
            var model = new ConstructionSitesListViewModel()
            {
                ConstructionSites = constructionSites,
                OpenStatus = openStatus,
                Cities = _citiesRepository.List().ToList(),
                SelectedCity = selectedCity,
            };
            return View(model);
        }

        // GET: ConstructionSites/Details/5
        public ActionResult Details(int id)
        {
            var model = _constructionSitesService.GetById(id);
            return View(model);
        }

        // GET: ConstructionSites/Create
        [Authorize]
        public ActionResult Create()
        {
            var cities = _citiesRepository.List().ToList();
            var constructionSite = new ConstructionSite();
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
        public async Task<ActionResult> Create(ConstructionSite constructionSite, IFormFile contractFile)
        {
            
            try
            {
                if (!ModelState.IsValid)
                {
                    var cities = _citiesRepository.List().ToList();
                    var viewModel = new CreateConstructionSiteViewModel()
                    {
                        constructionSite = constructionSite,
                        cities = cities,
                    };
                    return View(viewModel);
                }

                if (constructionSite.Id != 0)
                {
                    await _constructionSitesService.Update(constructionSite, contractFile);
                }
                else
                {
                    var user = await _userManager.GetUserAsync(HttpContext.User);
                    constructionSite.UserId = user.Id;
                    await _constructionSitesService.Store(constructionSite, contractFile);
                }

                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                _logger.LogError("Error creating construction site", e);
                return RedirectToAction("Create");
            }
        }

        // GET: ConstructionSites/Edit/5
        [Authorize]
        public ViewResult Edit(int id)
        {
            var viewModel = new CreateConstructionSiteViewModel()
            {
                constructionSite = _constructionSitesService.GetById(id),
                cities = _citiesRepository.List().ToList(),
            };
            return View("Create", viewModel);
        }

        // POST: ConstructionSites/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create");
                }
                
                //_constructionSitesService.Store(constructionSite, contractFile);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                _logger.LogError("Error creating construction site", e);
                return View("Create");
            }
        }

        // GET: ConstructionSites/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _constructionSitesService.GetById(id);
            return View(model);
        }

        // POST: ConstructionSites/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _constructionSitesService.DeleteById(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: ConstructionSites/SiteManagers/5
        [Authorize]
        [HttpPost]
        public void SiteManagers(int id, [FromBody] ConstructionSiteManager manager)
        {
            try
            {
                _constructionSitesService.AddConstructionSiteManager(id, manager);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }

        // GET: ConstructionSites/RemoveSiteManagers/5?managerId=2
        [Authorize]
        public ActionResult RemoveSiteManager(int id, int managerId)
        {
            try
            {
                _constructionSitesService.RemoveConstructionSiteManager(id, managerId);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return RedirectToAction("Edit", new {id= id});
        }

    }
}