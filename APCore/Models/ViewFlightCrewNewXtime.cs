using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewFlightCrewNewXTime
    {
        public int FDPId { get; set; }
        public int FDPItemId { get; set; }
        public int? CrewId { get; set; }
        public int? FlightId { get; set; }
        public bool? IsPositioning { get; set; }
        public string Name { get; set; }
        public string ScheduleName { get; set; }
        public int? GroupId { get; set; }
        public string JobGroup { get; set; }
        public string JobGroupCode { get; set; }
        public int SexId { get; set; }
        public int GroupOrder { get; set; }
        public int IsCockpit { get; set; }
        public int? BlockTime { get; set; }
        public int? FlightTime { get; set; }
        public int? FixTime { get; set; }
        public int? SITATime { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STDDay { get; set; }
        public int? FlightStatusID { get; set; }
    }
}
