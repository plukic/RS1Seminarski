using System;
using System.Collections.Generic;

namespace ConstructionDiary.Models
{
    public class Worksheet
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string WeatherConditions { get; set; }

        public List<Remark> Remarks { get; set; }
        public List<ControlEntry> ControlEntries { get; set; }
        public List<Task> Tasks { get; set; }
        public ConstructionSiteManager GetConstructionSiteManager { get; set; }
        public List<WorksheetTool> WorksheetTools { get; set; }
        public List<WorksheetMaterial> WorksheetMaterials { get; set; }
        public List<WorksheetMachine> WorksheetMachines { get; set; }
    }
}
