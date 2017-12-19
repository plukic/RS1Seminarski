using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionDiary.Models
{
    public class ConstructionSiteManager
    {
        public int Id { get; set; }

        public int UserId{ get; set; }
        public User User { get; set; }
        public List<Worksheet> Worksheets { get; set; }
    }
}
