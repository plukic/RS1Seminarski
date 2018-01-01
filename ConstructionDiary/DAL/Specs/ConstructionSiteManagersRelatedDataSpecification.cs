using DataLayer.Models;

namespace ConstructionDiary.DAL.Specs
{
    public class ConstructionSiteManagersRelatedDataSpecification : BaseSpecification<ConstructionSiteManager>
    {
        public ConstructionSiteManagersRelatedDataSpecification()
            : base(csm => true)
        {
            AddInclude(csm => csm.User);
        }

    }
}
