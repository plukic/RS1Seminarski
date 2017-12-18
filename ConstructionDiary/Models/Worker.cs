using System.Collections.Generic;

namespace GradjevinskiDnevnik.Models
{
    public class Worker: User
    {
        public string TelephoneNumber { get; set; }
        public List<WorkerTask> WorkerTasks { get; set; }
    }
}
