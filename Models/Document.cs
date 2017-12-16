using System;

namespace GradjevinskiDnevnik.Models
{
    public class Document
    {
        public int Id { get; set; }

        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
    }
}
