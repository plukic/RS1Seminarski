using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionDiary.ViewModels.ControlEntities
{
    public class ControlEntitiesIndexVM
    {
        public int WorksheetId { get; set; }
        public string WorksheetDescription { get; set; }
        public List<Row> Rows { get; set; }

        public class Row
        {
            public int ControleEntitiesId { get; set; }
            public string Date { get; set; }
            public string Text { get; set; }
            public string DocumentLink { get; set; }
            public string DocumentName { get; set; }
        }
    }
}
