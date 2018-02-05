using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Naziv")]
        public string Name { get; set; }

        [DisplayName("Datum kupovine")]
        public DateTime? PurchaseDate { get; set; }

        [DisplayName("Serijski broj")]
        public string SerialNumber { get; set; }

        [Required]
        [DefaultValue(1)]
        [DisplayName("Količina")]
        public int Quantity { get; set; }

        [Column(TypeName = "text")]
        [DisplayName("Opis")]
        [MinLength(4)]
        public string Description { get; set; }

        public List<WorksheetEquipment> WorksheetEquipment { get; set; }
    }
}
