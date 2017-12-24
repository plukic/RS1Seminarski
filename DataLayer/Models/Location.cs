using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class Location
    {
        public int Id { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        public string Address { get; set; }

        [NotMapped]
        public string Position
        {
            get => Latitude + ", " + Longitude;
        }
    }
}
