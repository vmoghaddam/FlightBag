using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewEFBVoyageReportsAll
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public DateTime? FlightDate { get; set; }
        public string AircraftType { get; set; }
        public string Register { get; set; }
        public string OriginIATA { get; set; }
        public string DestinationIATA { get; set; }
        public string Route { get; set; }
        public int? FlightId { get; set; }
        public int? RestReduction { get; set; }
        public int? DutyExtention { get; set; }
        public string Report { get; set; }
        public DateTime? DatePICSignature { get; set; }
        public int? ActionedById { get; set; }
        public DateTime? DateActioned { get; set; }
        public DateTime? DateConfirmed { get; set; }
        public string Name { get; set; }
        public string PID { get; set; }
        public string NID { get; set; }
        public string Mobile { get; set; }
    }
}
