using DataLayer.Models;
using System.Collections.Generic;

namespace ConstructionDiary.ViewModels
{

    public class ConstructionSitesListViewModel
    {
        public List<ConstructionSite> ConstructionSites { get; set; }

        public OpenStatus? OpenStatus { get; set; }

        public List<City> Cities { get; set; }

        public City SelectedCity { get; set; }
    }
}
