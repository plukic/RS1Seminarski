using System;

namespace DataLayer.Models
{
    public class Document
    {
        public int Id { get; set; }

        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public string DocumentDescription{ get; set; }
    }
}
