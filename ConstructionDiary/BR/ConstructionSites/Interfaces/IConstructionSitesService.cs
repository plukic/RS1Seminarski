using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructionDiary.BR.ConstructionSites.Interfaces
{
    public interface IConstructionSitesService
    {
        Task<ConstructionSite> Store(ConstructionSite constructionSite, IFormFile contract);
        List<ConstructionSite> GetAll();
        void DeleteById(int id);
        ConstructionSite GetById(int id);
    }
}
