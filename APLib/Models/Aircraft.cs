using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class Aircraft
    {
        public int Id { get; set; }
        public string Register { get; set; }
        public string AircraftType { get; set; }
        public int? TypeId { get; set; }
        public bool? IsVirtual { get; set; }
        public string TotalSeat { get; set; }
        public int? CustomerId { get; set; }
        public int? ModelId { get; set; }
        public int? AirlineOperatorsID { get; set; }
    }
}
