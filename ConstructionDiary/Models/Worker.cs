using System.Collections.Generic;

namespace ConstructionDiary.Models
{
    public class Worker: User
    {
        public string TelephoneNumber { get; set; }
        public List<WorkerTask> WorkerTasks { get; set; }
    }
}
