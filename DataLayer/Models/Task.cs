using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [Column(TypeName= "text")]
        public string Description { get; set; }

        public List<WorkerTask> WorkerTasks { get; set; }

        public int WorksheetId { get; set; }
        public Worksheet Worksheet{ get; set; }
    }
}
