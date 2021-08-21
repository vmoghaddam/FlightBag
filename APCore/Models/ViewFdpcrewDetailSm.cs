using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewFDPCrewDetailSM
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
        public DateTime? DateSent { get; set; }
        public string Ref { get; set; }
        public int? ResId { get; set; }
        public string ResStr { get; set; }
        public DateTime? ResDate { get; set; }
        public string Delivery { get; set; }
        public int? SMSId { get; set; }
    }
}
