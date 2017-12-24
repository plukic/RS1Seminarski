using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class ConstructionSite
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public decimal ProjectWorth { get; set; }

        [Required]
        public DateTime ?DateStart { get; set; }
        public DateTime ?DateFinish { get; set; }

        [Required]
        [DisplayName("City")]
        public int CityId { get; set; }
        [DisplayName("City")]
        public City City { get; set; }

        [Required]
        public int ContractId { get; set; }
        [Required]
        public Contract Contract { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

        [DisplayName("Created by")]
        public string UserId { get; set; }
        [DisplayName("Created by")]
        public User CreatedBy { get; set; }
    }
}
