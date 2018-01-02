using System;
using System.Collections.Generic;
using System.Linq;
using ConstructionDiary.BR.MaterialsManagement.Interfaces;
using ConstructionDiary.DAL;
using DataLayer.Models;

namespace ConstructionDiary.BR.MaterialsManagement.Implementation
{
    public class MaterialsService: IMaterialsService
    {
        private readonly IRepository<Material> _materialsRepository;

        public MaterialsService(
            IRepository<Material> materialsRepository)
        {
            _materialsRepository = materialsRepository;
        }
        public Material Store(Material material)
        {
            _materialsRepository.Add(material);
            return material;
        }

        public List<Material> GetAll()
        {
            return _materialsRepository.List().ToList();
        }

        public List<Material> GetAll(ISpecification<Material> specification)
        {
            return _materialsRepository.List(specification).ToList();
        }

        public void DeleteById(int id)
        {
            var material = _materialsRepository.GetById(id);
            _materialsRepository.Delete(material);
        }

        public Material GetById(int id)
        {
            return _materialsRepository.GetById(id);
        }

        public void Update(Material material)
        {

            try
            {
                _materialsRepository.Edit(material);
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }

    }
}
