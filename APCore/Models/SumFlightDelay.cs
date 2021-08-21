using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class SumFlightDelay
    {
        public int ID { get; set; }
        public string FlightNumber { get; set; }
        public DateTime? STDDay { get; set; }
        public int Delay { get; set; }
    }
}
