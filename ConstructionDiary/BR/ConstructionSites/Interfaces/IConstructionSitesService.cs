using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructionDiary.DAL;
using Task = System.Threading.Tasks.Task;

namespace ConstructionDiary.BR.ConstructionSites.Interfaces
{
    public interface IConstructionSitesService
    {
        Task<ConstructionSite> Store(ConstructionSite constructionSite, IFormFile contract);
        List<ConstructionSite> GetAll();
        List<ConstructionSite> GetAll(ISpecification<ConstructionSite> specification);
        void DeleteById(int id);
        ConstructionSite GetById(int id);
        Task Update(ConstructionSite constructionSite, IFormFile contractFile);
        void AddConstructionSiteManager(int id, ConstructionSiteManager manager);
        void RemoveConstructionSiteManager(int id, int managerId);
    }
}
