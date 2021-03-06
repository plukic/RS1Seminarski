﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class Location
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Latitude is required")]
        public double? Latitude { get; set; }
        [Required(ErrorMessage = "Longitude is required")]
        public double? Longitude { get; set; }
        public string Address { get; set; }

        [NotMapped]
        public string Position
        {
            get
            {
                if (Latitude == 0 || Longitude == 0)
                {
                    return null;
                }
                return String.Format("{0:0.0000}", Latitude) + ", " + String.Format("{0:0.0000}", Longitude);
            }
        }
    }
}
