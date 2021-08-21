using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewFDPCrewDetail
    {
        public int? FDPId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ScheduleName { get; set; }
        public string Position { get; set; }
        public int? PositionId { get; set; }
        public int? RosterPositionId { get; set; }
        public string Mobile { get; set; }
        public string Route { get; set; }
        public string Flights { get; set; }
        public DateTime? DaySTDLocal { get; set; }
        public DateTime? DepartureLocal { get; set; }
        public DateTime? ArrivalLocal { get; set; }
    }
}
