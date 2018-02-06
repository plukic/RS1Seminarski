using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    [DisplayName("Jedinica")]
    public enum MeasurementUnit
    {
        [Display(Name = "kg.")]
        Kilogram,
        [Display(Name = "l.")]
        Litre,
    };
    public class Material
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Naziv")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Količina")]
        [DefaultValue(1)]
        public double? Amount { get; set; }

        [DisplayName("Mijerna jedinica")]
        [DefaultValue(MeasurementUnit.Kilogram)]
        public MeasurementUnit Unit { get; set; }
   
        public List<WorksheetMaterial> WorksheetMaterials { get; set; }
    }
}
