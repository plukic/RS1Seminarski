using System;

namespace DataLayer.Models
{
    public class WorksheetEquipment
    {
        public DateTime UsageStart { get; set; }
        public DateTime UsageEnd{ get; set; }

        public int WorksheetId { get; set; }
        public Worksheet Worksheet { get; set; }

        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
    }
}
