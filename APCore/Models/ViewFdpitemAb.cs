using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewFDPItemAb
    {
        public int Id { get; set; }
        public int FDPId { get; set; }
        public int? FlightId { get; set; }
        public bool? IsSector { get; set; }
        public bool? IsOff { get; set; }
        public bool? IsPositioning { get; set; }
        public int? FlightStatusID { get; set; }
    }
}
