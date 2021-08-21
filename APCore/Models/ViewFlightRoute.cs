using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewFlightRoute
    {
        public int Id { get; set; }
        public int AirlineId { get; set; }
        public int FromAirportId { get; set; }
        public string FromAirportIATA { get; set; }
        public string FromAirportName { get; set; }
        public int ToAirportId { get; set; }
        public string ToAirportIATA { get; set; }
        public string ToAirportName { get; set; }
        public string Title { get; set; }
        public int? Stops { get; set; }
        public string Equipment { get; set; }
        public int? FlightH { get; set; }
        public int? FlightM { get; set; }
        public decimal? ToAirportLatitude { get; set; }
        public decimal? ToAirportLongitude { get; set; }
        public decimal? FromAirportLatitude { get; set; }
        public decimal? FromAirportLongitude { get; set; }
        public int? FromCityId { get; set; }
        public string FromCity { get; set; }
        public string FromCountry { get; set; }
        public int FromCountryId { get; set; }
        public string FromSortName { get; set; }
        public int? ToCityId { get; set; }
        public string ToCity { get; set; }
        public int ToCountryId { get; set; }
        public string ToSortName { get; set; }
        public string ToCountry { get; set; }
    }
}
