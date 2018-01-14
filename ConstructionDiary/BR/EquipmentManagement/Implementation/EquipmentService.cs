using ConstructionDiary.BR.EquipmentManagement.Interfaces;
using ConstructionDiary.DAL;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstructionDiary.BR.EquipmentManagement.Implementation
{
    public class EquipmentService: IEquipmentService
    {
        private readonly IRepository<Equipment> _equipmentRepository;

        public EquipmentService(
            IRepository<Equipment> equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }
        public Equipment Store(Equipment equipment)
        {
            _equipmentRepository.Add(equipment);
            return equipment;
        }

        public List<Equipment> GetAll()
        {
            return _equipmentRepository.List().ToList();
        }

        public List<Equipment> GetAll(ISpecification<Equipment> specification)
        {
            return _equipmentRepository.List(specification).ToList();
        }

        public void DeleteById(int id)
        {
            var equipment = _equipmentRepository.GetById(id);
            _equipmentRepository.Delete(equipment);
        }

        public Equipment GetById(int id)
        {
            return _equipmentRepository.GetById(id);
        }

        public void Update(Equipment equipment)
        {

            try
            {
                _equipmentRepository.Edit(equipment);
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }

    }
}
