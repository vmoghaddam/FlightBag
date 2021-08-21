using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewRouteToAirport
    {
        public string Name { get; set; }
        public string IATA { get; set; }
        public string ICAO { get; set; }
        public int CityId { get; set; }
        public int Id { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public string SortName { get; set; }
        public string Country { get; set; }
        public string Type { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int AirlineId { get; set; }
    }
}
