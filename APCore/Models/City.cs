using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class City
    {
        public City()
        {
            Airports = new HashSet<Airport>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? StateId { get; set; }
        public string AccuWeatherCode { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

        public virtual ICollection<Airport> Airports { get; set; }
    }
}
