using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class HelperFuelAvgReg
    {
        public string FromAirportIATA { get; set; }
        public string ToAirportIATA { get; set; }
        public int? TypeId { get; set; }
        public string AircraftType { get; set; }
        public int? RegisterID { get; set; }
        public string Register { get; set; }
        public decimal? AVGFuelBurned { get; set; }
    }
}
