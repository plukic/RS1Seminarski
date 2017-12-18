using System;
using System.Collections.Generic;

namespace GradjevinskiDnevnik.Models
{
    public class Machine
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime PurchaseDate { get; set; }

        public List<WorksheetMachine> WorksheetMachines { get; set; }
    }
}
