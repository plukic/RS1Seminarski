using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradjevinskiDnevnik.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [Column(TypeName= "text")]
        public string Description { get; set; }

        public List<WorkerTask> WorkerTasks { get; set; }
    }
}
