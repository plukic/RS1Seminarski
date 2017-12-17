using System.Collections.Generic;

namespace GradjevinskiDnevnik.Models
{
    public class ConstructionSiteManager: User
    {
        public string Email { get; set; }
        public List<Worksheet> Worksheets { get; set; }
    }
}
