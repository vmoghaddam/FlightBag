using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class FlightCrewArchived
    {
        public int Id { get; set; }
        public int? FlightId { get; set; }
        public int? CrewId { get; set; }
        public string Position { get; set; }
        public string Route { get; set; }
        public DateTime? Date { get; set; }
        public string FlightNo { get; set; }
    }
}
