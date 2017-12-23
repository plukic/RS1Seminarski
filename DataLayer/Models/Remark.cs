using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionDiary.Models
{
    public class Remark
    {
        public int Id { get; set; }

        [Column(TypeName="text")]
        public string Text { get; set; }

        public DateTime DateTime { get; set; }

        public Worksheet Worksheet { get; set; }
        public int WorksheetId { get; set; }
    }
}
