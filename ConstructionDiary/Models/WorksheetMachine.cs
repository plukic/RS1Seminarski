using System;

namespace GradjevinskiDnevnik.Models
{
    public class WorksheetMachine
    {
        public DateTime UsageStart { get; set; }
        public DateTime UsageEnd{ get; set; }

        public int WorksheetId { get; set; }
        public Worksheet Worksheet { get; set; }

        public int MachineId { get; set; }
        public Machine Machine { get; set; }
    }
}
