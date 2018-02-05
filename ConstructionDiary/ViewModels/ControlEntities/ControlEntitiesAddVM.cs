using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionDiary.ViewModels.ControlEntities
{
    public class ControlEntitiesAddVM
    {
        public int WorksheetId { get; set; }
        [Required]
        public string Text{ get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        
    }
}
