using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APCore.ViewModels
{
    public class LogViewModel
    {
        public int FlightId { get; set; }
        public int CrewId { get; set; }
        public string BlockOff { get; set; }
        public string BlockOn { get; set; }
        public string TakeOff { get; set; }
        public string Landing { get; set; }

        public decimal? FuelRemaining { get; set; }
        public decimal? FuelUplift { get; set; }
        public decimal? FuelUsed { get; set; }
        public decimal? FuelDensity { get; set; }

        public int? PaxAdult { get; set; }
        public int? PaxChild { get; set; }
        public int? PaxInfant { get; set; }

        public int? BaggageWeight { get; set; }
        public int? CargoWeight { get; set; }

        public string SerialNo { get; set; }
        public string LTR { get; set; }
        public string PF { get; set; }

        public decimal? RVSM_GND_CPT { get; set; }
        public decimal? RVSM_GND_STBY { get; set; }
        public decimal? RVSM_GND_FO { get; set; }

        public decimal? RVSM_FLT_CPT { get; set; }
        public decimal? RVSM_FLT_STBY { get; set; }
        public decimal? RVSM_FLT_FO { get; set; }
        public bool? AttRepositioning1 { get; set; }
        public bool? AttRepositioning2 { get; set; }
        public string CommanderNote { get; set; }

        public DateTime? BlockOffDate { get; set; }
        public DateTime? BlockOnDate { get; set; }
        public DateTime? TakeOffDate { get; set; }
        public DateTime? LandingDate { get; set; }

        public int Version { get; set; }
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }
         
    }


}
