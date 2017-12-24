using System.Collections.Generic;

namespace DataLayer.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobDescription { get; set; }
        public string TelephoneNumber { get; set; }
        public List<WorkerTask> WorkerTasks { get; set; }
    }
}
