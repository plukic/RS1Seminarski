using DataLayer.Models;

namespace ConstructionDiary.DAL.Specs
{
    public class ConstructionSiteSiteManagerSpecification : BaseSpecification<ConstructionSiteSiteManager>
    {
        public ConstructionSiteSiteManagerSpecification(int siteId, int managerId)
            : base(cssm => cssm.ConstructionSiteId == siteId && cssm.ConstructionSiteManagerId == managerId)
        {

        }

    }
}
