using DataLayer.Models;

namespace ConstructionDiary.DAL.Specs
{
    public class EquipmentFilters : BaseSpecification<Equipment>
    {
        public EquipmentFilters(string name)
            : base(e => e.Name.Contains(name))
        {
            
        }

    }
}
