using ConstructionDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionDiary.ViewModels
{
    public class CreateConstructionSiteViewModel
    {
        public ConstructionSite constructionSite;

        public Contract contract;

        public List<City> cities;
    }
}
