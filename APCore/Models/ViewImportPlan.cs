using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewImportPlan
    {
        public DateTime Date { get; set; }
        public string Base { get; set; }
        public int BaseId { get; set; }
        public string Type { get; set; }
        public string Reg { get; set; }
        public int RegId { get; set; }
        public string AircraftType { get; set; }
        public int? AircraftTypeId { get; set; }
        public string No { get; set; }
        public string From { get; set; }
        public int FromId { get; set; }
        public string To { get; set; }
        public int ToId { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public string Duration { get; set; }
        public int? FlightTime { get; set; }
        public DateTime? STDUtc { get; set; }
        public DateTime? STAUtc { get; set; }
        public string Line { get; set; }
        public int LineId { get; set; }
        public int? RouteId { get; set; }
    }
}
