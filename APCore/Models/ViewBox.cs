using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewBox
    {
        public int Id { get; set; }
        public int FlightPlanId { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? DefaultStart { get; set; }
        public DateTime? STA { get; set; }
        public DateTime? DefaultEnd { get; set; }
        public int? FromAirportId { get; set; }
        public int? ToAirportId { get; set; }
        public DateTime? Date { get; set; }
        public int? CalanderId { get; set; }
        public string Flights { get; set; }
        public int? Duty { get; set; }
        public int? ScheduledDuty { get; set; }
        public int? Flight { get; set; }
        public int? FDP { get; set; }
        public int? ScheduledFDP { get; set; }
        public int? NotAllAssignedCount { get; set; }
        public int? CrewProblemCount { get; set; }
        public int? AssignedCrewCount { get; set; }
        public DateTime? RestUntil { get; set; }
        public DateTime? RestFrom { get; set; }
        public double? MaxFDP { get; set; }
        public double? MaxFDPExtended { get; set; }
        public int IsDutyOver { get; set; }
        public int? WOCL { get; set; }
        public int WOCLError { get; set; }
        public int? Sector { get; set; }
        public int? DelayAmount { get; set; }
        public DateTime? DelayedReportingTime { get; set; }
    }
}
