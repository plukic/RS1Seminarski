using ConstructionDiary.DAL;
using DataLayer.Models;
using System.Collections.Generic;

namespace ConstructionDiary.BR.EquipmentManagement.Interfaces
{
    public interface IEquipmentService
    {
        Equipment Store(Equipment equipment);
        List<Equipment> GetAll();
        List<Equipment> GetAll(ISpecification<Equipment> equipment);
        void DeleteById(int id);
        Equipment GetById(int id);
        void Update(Equipment equipment);
    }
}
