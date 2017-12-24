using System.Collections.Generic;

namespace DataLayer.Models
{
    public class ConstructionSiteManager
    {
        public int Id { get; set; }

        public int UserId{ get; set; }
        public User User { get; set; }
        public List<Worksheet> Worksheets { get; set; }
    }
}
