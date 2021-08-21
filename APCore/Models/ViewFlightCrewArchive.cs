using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewFlightCrewArchive
    {
        public int? GroupId { get; set; }
        public string JobGroup { get; set; }
        public string JobGroupCode { get; set; }
        public string Name { get; set; }
        public string ScheduleName { get; set; }
        public int IsCockpit { get; set; }
        public int SexId { get; set; }
        public string Sex { get; set; }
        public int? FlightId { get; set; }
        public int? CrewId { get; set; }
        public string Position { get; set; }
        public DateTime? Date { get; set; }
        public string FlightNo { get; set; }
        public int Id { get; set; }
        public int GroupOrder { get; set; }
        public string Code { get; set; }
    }
}
