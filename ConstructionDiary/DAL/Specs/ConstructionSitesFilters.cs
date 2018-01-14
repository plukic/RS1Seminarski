using DataLayer.Models;

namespace ConstructionDiary.DAL.Specs
{
    public class ConstructionSitesFilters : BaseSpecification<ConstructionSite>
    {
        public ConstructionSitesFilters(OpenStatus? openStatus, City selectedCity)
            : base(cs => (openStatus == null || cs.OpenStatus == openStatus) && (selectedCity == null || cs.City.Equals(selectedCity)))
        {
            AddInclude(c => c.City);
            AddInclude(c => c.Contract);
            AddInclude(c => c.Contract.Document);
            AddInclude(c => c.CreatedBy);
            AddInclude(c => c.Location);
        }

    }
}
