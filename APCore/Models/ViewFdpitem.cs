using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewFDPItem
    {
        public int Id { get; set; }
        public int FDPId { get; set; }
        public int? FlightId { get; set; }
        public bool? IsSector { get; set; }
        public bool? IsOff { get; set; }
        public bool? IsPositioning { get; set; }
        public bool? IsCanceled { get; set; }
        public string FlightNumber { get; set; }
        public DateTime? DepartureLocal { get; set; }
        public DateTime? DepartureDay { get; set; }
        public DateTime? ArrivalLocal { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? Arrival { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public int? FlightStatusID { get; set; }
        public int? FromAirport { get; set; }
        public int? FromAirportCityId { get; set; }
        public int? ToAirport { get; set; }
        public string FromAirportIATA { get; set; }
        public string ToAirportIATA { get; set; }
        public int? ACTypeId { get; set; }
        public string Register { get; set; }
        public string AircraftType { get; set; }
        public int? Break { get; set; }
        public int? WOCL { get; set; }
        public decimal? SplitDutyExtension { get; set; }
        public int? SplitDutyPairId { get; set; }
        public bool? SplitDuty { get; set; }
        public long? Rank { get; set; }
        public long? RankDesc { get; set; }
        public int? PositionId { get; set; }
        public int? RosterPositionId { get; set; }
        public string Position { get; set; }
    }
}
