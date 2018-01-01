using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    [DisplayName("Status")]
    public enum OpenStatus
    {
        [Display(Name="Otvoreno")]
        Open,
        [Display(Name = "Zatvoreno")]
        Closed,
    };
    public class ConstructionSite
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Naziv")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Vrijednost projekta")]
        public decimal ProjectWorth { get; set; }

        [DisplayName("Status")]
        [DefaultValue(Models.OpenStatus.Open)]
        public OpenStatus OpenStatus { get; set; }

        [Required]
        [DisplayName("Datum otvaranja")]
        public DateTime ?DateStart { get; set; }
        [DisplayName("Datum zatvaranje")]
        public DateTime ?DateFinish { get; set; }

        [Required]
        [DisplayName("Grad")]
        public int CityId { get; set; }
        [DisplayName("Grad")]
        public City City { get; set; }

        [Required]
        public int ContractId { get; set; }
        [Required]
        [DisplayName("Ugovor")]
        public Contract Contract { get; set; }

        public int LocationId { get; set; }
        [Required]
        [DisplayName("Lokacija")]
        public Location Location { get; set; }

        [DisplayName("Kreirao/la")]
        public string UserId { get; set; }
        [DisplayName("Kreirao/la")]
        public User CreatedBy { get; set; }

        public List<ConstructionSiteSiteManager> ConstructionSiteManagers { get; set; }
    }
}
