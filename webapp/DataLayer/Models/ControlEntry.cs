﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class ControlEntry
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [Column(TypeName="text")]
        public string Text { get; set; }

        public int DocumentId { get; set; }
        public Document Document { get; set; }

        public int WorksheetId { get; set; }
        public Worksheet Worksheet { get; set; }
    }
}
