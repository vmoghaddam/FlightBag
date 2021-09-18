using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class ViewFDPCrew
    {
        public int Id { get; set; }
        public int? FDPId { get; set; }
        public string Name { get; set; }
        public string ScheduleName { get; set; }
        public string Position { get; set; }
        public int? PositionId { get; set; }
        public int? RosterPositionId { get; set; }
        public string Mobile { get; set; }
    }
}
