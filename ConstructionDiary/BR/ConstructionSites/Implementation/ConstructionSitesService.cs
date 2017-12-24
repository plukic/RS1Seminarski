using ConstructionDiary.BR.ConstructionSites.Interfaces;
using ConstructionDiary.BR.Documents.Interfaces;
using ConstructionDiary.DAL;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionDiary.DAL.Specs;
using DataLayer.Models;

namespace ConstructionDiary.BR.ConstructionSites.Implementation
{
    public class ConstructionSitesService: IConstructionSitesService
    {
        private readonly IRepository<ConstructionSite> _constructionSitesRepository;
        private readonly IRepository<Location> _locationsRepository;
        private readonly IDocumentsService _documentsService;
  
        public ConstructionSitesService(
            IRepository<ConstructionSite> constructionSitesRepository,
            IRepository<Location> locationsRepository,
            IDocumentsService documentsService)
        {
            _constructionSitesRepository = constructionSitesRepository;
            _documentsService = documentsService;
            _locationsRepository = locationsRepository;
        }
        public async Task<ConstructionSite> Store(ConstructionSite constructionSite, IFormFile contract)
        {
            Document document = await _documentsService.Store(contract, "opis");

            constructionSite.Contract.Document = document;
            constructionSite.Contract.Date = DateTime.Now;
            var tempLocation = new Location();
            _locationsRepository.Add(tempLocation);
            constructionSite.LocationId = tempLocation.Id;

            _constructionSitesRepository.Add(constructionSite);
            return constructionSite;
        }

        public List<ConstructionSite> GetAll()
        {
            var specification = new ConstructionSiteAllRelatedDataSpecification();
            return _constructionSitesRepository.List(specification).ToList();
        }

        public void DeleteById(int id)
        {
            var constructionSite = _constructionSitesRepository.GetById(id);
            _constructionSitesRepository.Delete(constructionSite);
        }

        public ConstructionSite GetById(int id)
        {
            var specification = new ConstructionSiteAllRelatedDataSpecification(id);
            return _constructionSitesRepository.GetSingle(specification);
        }
    }
}
