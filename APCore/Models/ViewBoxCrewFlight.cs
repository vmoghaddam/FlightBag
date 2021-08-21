using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewBoxCrewFlight
    {
        public DateTime? STDFirst { get; set; }
        public DateTime? STAFirst { get; set; }
        public int? CalanderId { get; set; }
        public int BoxId { get; set; }
        public int JobGroupId { get; set; }
        public int EmployeeId { get; set; }
        public int? AvailabilityId { get; set; }
        public string Remark { get; set; }
        public DateTime? Date { get; set; }
        public string DateStr { get; set; }
        public int FlightPlanId { get; set; }
        public int FlightId { get; set; }
        public int? FlightH { get; set; }
        public byte? FlightM { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public string FlightNumber { get; set; }
        public int? FromAirport { get; set; }
        public int? ToAirport { get; set; }
        public string FromAirportIATA { get; set; }
        public string ToAirportIATA { get; set; }
        public decimal FlightTime { get; set; }
        public decimal DutyTime { get; set; }
    }
}
