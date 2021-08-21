using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewBirdStrikeCAO
    {
        public string ReportedByName { get; set; }
        public string OperatorName { get; set; }
        public string LocalTime { get; set; }
        public string PhaseOrFlight { get; set; }
        public string SkyCondition { get; set; }
        public string BirdNrSeen { get; set; }
        public string BirdNrStruck { get; set; }
        public string BirdSize { get; set; }
    }
}
