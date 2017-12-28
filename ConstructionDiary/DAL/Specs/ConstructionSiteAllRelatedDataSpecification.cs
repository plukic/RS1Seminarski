using DataLayer.Models;

namespace ConstructionDiary.DAL.Specs
{
    public class ConstructionSiteAllRelatedDataSpecification : BaseSpecification<ConstructionSite>
    {
        public ConstructionSiteAllRelatedDataSpecification()
            : base(c => true)
        {
            AddInclude(c => c.City);
            AddInclude(c => c.Contract);
            AddInclude(c => c.Contract.Document);
            AddInclude(c => c.CreatedBy);
            AddInclude(c => c.Location);
        }

        public ConstructionSiteAllRelatedDataSpecification(int id)
            : base(c => c.Id == id)
        {
            AddInclude(c => c.City);
            AddInclude(c => c.Contract);
            AddInclude(c => c.Contract.Document);
            AddInclude(c => c.CreatedBy);
            AddInclude(c => c.Location);
        }
    }
}
