using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;

namespace ConstructionDiary.ViewModels
{
    public class CreateConstructionSiteViewModel
    {
        public ConstructionSite constructionSite;

        public Contract contract;

        public List<City> cities;
    }
}
