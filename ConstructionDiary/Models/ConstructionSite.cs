using System;
using System.ComponentModel.DataAnnotations;

namespace ConstructionDiary.Models
{
    public class ConstructionSite
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [Required]
        public decimal ProjectWorth { get; set; }

        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }

        [Required]
        public int CityId { get; set; }
        public City City { get; set; }

        public int ContractId { get; set; }
        public Contract Contract { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

        public string UserId { get; set; }
        public User CreatedBy { get; set; }
    }
}
