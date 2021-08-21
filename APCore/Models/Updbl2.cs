using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class updbl2
    {
        public int Id { get; set; }
        public int SourceAirportId { get; set; }
        public int DestinationAirportId { get; set; }
        public int? FlightH { get; set; }
        public int? FlightM { get; set; }
        public string ORG { get; set; }
        public string DES { get; set; }
        public int? ORGID { get; set; }
        public int? DESID { get; set; }
        public int? HH { get; set; }
        public int? MM { get; set; }
    }
}
