using DataLayer.Models;

namespace ConstructionDiary.DAL.Specs
{
    public class ConstructionSitesFilters : BaseSpecification<ConstructionSite>
    {
        public ConstructionSitesFilters(OpenStatus openStatus)
            : base(c => openStatus == OpenStatus.All || c.OpenStatus == openStatus)
        {
            AddInclude(c => c.City);
            AddInclude(c => c.Contract);
            AddInclude(c => c.Contract.Document);
            AddInclude(c => c.CreatedBy);
        }

    }
}
