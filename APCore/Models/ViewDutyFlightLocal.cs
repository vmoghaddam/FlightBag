using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewDutyFlightLocal
    {
        public int Id { get; set; }
        public int FDPId { get; set; }
        public int? FlightId { get; set; }
        public DateTime? CDate { get; set; }
        public DateTime? DatePart { get; set; }
        public int? Year { get; set; }
        public int? CrewId { get; set; }
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
        public int? DurationLocal { get; set; }
    }
}
