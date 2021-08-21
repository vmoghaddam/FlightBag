using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewFlightCrewArchived
    {
        public int Id { get; set; }
        public int? FlightId { get; set; }
        public int? CrewId { get; set; }
        public string Position { get; set; }
        public string Name { get; set; }
        public string ScheduleName { get; set; }
        public string Route { get; set; }
        public DateTime? Date { get; set; }
        public string FlightNo { get; set; }
    }
}
