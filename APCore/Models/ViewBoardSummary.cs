using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewBoardSummary
    {
        public DateTime Date { get; set; }
        public int? TotalFlight { get; set; }
        public int? Departed { get; set; }
        public int? Arrived { get; set; }
        public int? Diverted { get; set; }
        public int? Canceled { get; set; }
        public int BlockTime { get; set; }
        public int FlightTimeActual { get; set; }
        public int FlightTime { get; set; }
        public int FixTime { get; set; }
        public int SITATime { get; set; }
        public int Delay { get; set; }
        public int Pax { get; set; }
        public int PaxAdult { get; set; }
        public int PaxChild { get; set; }
        public int PaxInfant { get; set; }
        public decimal PaxLoad { get; set; }
        public int TotalSeat { get; set; }
        public int BaggageWeight { get; set; }
        public int CargoWeight { get; set; }
        public int BaggageCount { get; set; }
        public int CargoCount { get; set; }
        public decimal FuelActual { get; set; }
        public decimal FuelUplift { get; set; }
    }
}
