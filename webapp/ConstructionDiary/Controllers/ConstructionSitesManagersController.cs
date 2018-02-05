using System.Collections.Generic;
using ConstructionDiary.DAL;
using ConstructionDiary.DAL.Specs;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ConstructionDiary.Controllers
{
    public class ConstructionSitesManagersController : Controller
    {
        private readonly IRepository<ConstructionSiteManager> _siteManagersRepository;

        public ConstructionSitesManagersController(IRepository<ConstructionSiteManager> siteManagersRepository)
        {
            _siteManagersRepository = siteManagersRepository;
        }

        // GET: ConstructionSitesManagers
        public ActionResult Index()
        {
            ISpecification<ConstructionSiteManager> spec = new ConstructionSiteManagersRelatedDataSpecification();
            List<ConstructionSiteManager> allSiteManagers = _siteManagersRepository.List(spec).ToList();
            return Json(new {data= allSiteManagers});
        }

    }
}