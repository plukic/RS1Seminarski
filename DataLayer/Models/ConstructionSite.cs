using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public enum OpenStatus
    {
        Open,
        Closed,
    };
    public class ConstructionSite
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        [DisplayName("Project worth")]
        public decimal ProjectWorth { get; set; }

        [DefaultValue(Models.OpenStatus.Open)]
        public OpenStatus OpenStatus { get; set; }

        [Required]
        [DisplayName("Site opening date")]
        public DateTime ?DateStart { get; set; }
        [DisplayName("Site closing date")]
        public DateTime ?DateFinish { get; set; }

        [Required]
        [DisplayName("City")]
        public int CityId { get; set; }
        public City City { get; set; }

        [Required]
        public int ContractId { get; set; }
        [Required]
        public Contract Contract { get; set; }

        public int LocationId { get; set; }
        [Required]
        public Location Location { get; set; }

        [DisplayName("Created by")]
        public string UserId { get; set; }
        [DisplayName("Created by")]
        public User CreatedBy { get; set; }
    }
}
