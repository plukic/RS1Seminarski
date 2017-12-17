using System;

namespace GradjevinskiDnevnik.Models
{
    public class ConstructionSite
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public decimal ProjectWorth { get; set; }

        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public int ContractId { get; set; }
        public Contract Contract { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

        public int ManagerId { get; set; }
        public Manager CreatedBy { get; set; }
    }
}
