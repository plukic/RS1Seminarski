using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string SerialNumber { get; set; }

        public List<WorksheetEquipment> WorksheetEquipment { get; set; }
    }
}
