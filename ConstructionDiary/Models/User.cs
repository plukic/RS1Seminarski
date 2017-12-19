using System;

namespace ConstructionDiary.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
    }
}
