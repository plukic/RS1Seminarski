using System.Collections.Generic;

namespace GradjevinskiDnevnik.Models
{
    public class Tool
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public List<WorksheetTool> WorksheetTools { get; set; }
    }
}
