using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewVoyageReport
    {
        public int Id { get; set; }
        public string Route { get; set; }
        public int? FlightId { get; set; }
        public int? RestReduction { get; set; }
        public int? DutyExtention { get; set; }
        public string Report { get; set; }
        public DateTime? DatePICSignature { get; set; }
        public int? ActionedById { get; set; }
        public DateTime? DateActioned { get; set; }
        public DateTime? DateConfirmed { get; set; }
        public string Irr { get; set; }
        public string Reason { get; set; }
        public string Name { get; set; }
    }
}
