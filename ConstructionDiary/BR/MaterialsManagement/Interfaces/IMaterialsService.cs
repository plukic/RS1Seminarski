using System.Collections.Generic;
using ConstructionDiary.DAL;
using DataLayer.Models;

namespace ConstructionDiary.BR.MaterialsManagement.Interfaces
{
    public interface IMaterialsService
    {
        Material Store(Material material);
        List<Material> GetAll();
        List<Material> GetAll(ISpecification<Material> material);
        void DeleteById(int id);
        Material GetById(int id);
        void Update(Material material);
    }
}
