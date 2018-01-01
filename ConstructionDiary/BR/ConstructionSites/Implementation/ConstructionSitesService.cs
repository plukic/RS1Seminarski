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
using Task = System.Threading.Tasks.Task;

namespace ConstructionDiary.BR.ConstructionSites.Implementation
{
    public class ConstructionSitesService: IConstructionSitesService
    {
        private readonly IRepository<ConstructionSite> _constructionSitesRepository;
        private readonly IRepository<Location> _locationsRepository;
        private readonly IDocumentsService _documentsService;
        private readonly IRepository<ConstructionSiteSiteManager> _constructionSiteSetManagersRepository;

        public ConstructionSitesService(
            IRepository<ConstructionSite> constructionSitesRepository,
            IRepository<Location> locationsRepository,
            IDocumentsService documentsService,
            IRepository<ConstructionSiteSiteManager> constructionSiteSetManagersRepository)
        {
            _constructionSitesRepository = constructionSitesRepository;
            _documentsService = documentsService;
            _locationsRepository = locationsRepository;
            _constructionSiteSetManagersRepository = constructionSiteSetManagersRepository;
        }
        public async Task<ConstructionSite> Store(ConstructionSite constructionSite, IFormFile contract)
        {
            Document document = await _documentsService.Store(contract, "opis");
            _locationsRepository.Add(constructionSite.Location);

            constructionSite.Contract.Document = document;
            constructionSite.Contract.Date = DateTime.Now;

            _constructionSitesRepository.Add(constructionSite);
            return constructionSite;
        }

        public List<ConstructionSite> GetAll()
        {
            var specification = new ConstructionSiteAllRelatedDataSpecification();
            return _constructionSitesRepository.List(specification).ToList();
        }

        public List<ConstructionSite> GetAll(ISpecification<ConstructionSite> specification)
        {
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

        public async Task Update(ConstructionSite constructionSite, IFormFile contractFile)
        {
            if (contractFile != null)
            {
                constructionSite.Contract.Document =
                    await _documentsService.Update(constructionSite.Contract.Document, contractFile);
            }


            constructionSite.Contract.Date = DateTime.Now;
            _locationsRepository.Edit(constructionSite.Location);

            constructionSite.ContractId = constructionSite.Contract.Id;

            try
            {
                _constructionSitesRepository.Edit(constructionSite);
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }

        public void AddConstructionSiteManager(int id, ConstructionSiteManager manager)
        {
            _constructionSiteSetManagersRepository.Add(new ConstructionSiteSiteManager()
            {
                ConstructionSiteId = id,
                ConstructionSiteManagerId = manager.Id,
            });
        }
    }
}
