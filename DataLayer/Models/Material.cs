using System.Collections.Generic;

namespace ConstructionDiary.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public List<WorksheetMaterial> WorksheetMaterials { get; set; }
    }
}
