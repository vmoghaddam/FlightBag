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


    public class LogViewModel2
    {
        public int FlightId { get; set; }
        public int CrewId { get; set; }
        public string BlockOff { get; set; }
        public string BlockOffDt { get; set; }
        public string BlockOn { get; set; }
        public string BlockOnDt { get; set; }
        public string TakeOff { get; set; }
        public string TakeOffDt { get; set; }

        public string Landing { get; set; }
        public string LandingDt { get; set; }

        public decimal? FuelRemaining { get; set; }
        public string FuelRemainingDt { get; set; }
        public decimal? FuelUplift { get; set; }
        public string FuelUpliftDt { get; set; }
        public decimal? FuelUsed { get; set; }
        public string FuelUsedDt { get; set; }
        public decimal? FuelDensity { get; set; }
        public string FuelDensityDt { get; set; }

        public int? PaxAdult { get; set; }
        public string PaxAdultDt { get; set; }
        public int? PaxChild { get; set; }
        public string PaxChildDt { get; set; }
        public int? PaxInfant { get; set; }
        public string PaxInfantDt { get; set; }

        public int? BaggageWeight { get; set; }
        public string BaggageWeightDt { get; set; }
        public int? CargoWeight { get; set; }
        public string CargoWeightDt { get; set; }

        public string SerialNo { get; set; }
        public string SerialNoDt { get; set; }
        public string LTR { get; set; }
        public string LTRDt { get; set; }
        public string PF { get; set; }
        public string PFDt { get; set; }

        public decimal? RVSM_GND_CPT { get; set; }
        public string RVSM_GND_CPTDt { get; set; }
        public decimal? RVSM_GND_STBY { get; set; }
        public string RVSM_GND_STBYDt { get; set; }
        public decimal? RVSM_GND_FO { get; set; }
        public string RVSM_GND_FODt { get; set; }

        public decimal? RVSM_FLT_CPT { get; set; }
        public string RVSM_FLT_CPTDt { get; set; }
        public decimal? RVSM_FLT_STBY { get; set; }
        public string RVSM_FLT_STBYDt { get; set; }
        public decimal? RVSM_FLT_FO { get; set; }
        public string RVSM_FLT_FODt { get; set; }
        public bool? AttRepositioning1 { get; set; }
        public string AttRepositioning1Dt { get; set; }
        public bool? AttRepositioning2 { get; set; }
        public string AttRepositioning2Dt { get; set; }
        public string CommanderNote { get; set; }
        public string CommanderNoteDt { get; set; }

        public DateTime? BlockOffDate { get; set; }
        public DateTime? BlockOnDate { get; set; }
        public DateTime? TakeOffDate { get; set; }
        public DateTime? LandingDate { get; set; }

        public string BlockOffDateDt { get; set; }
        public string BlockOnDateDt { get; set; }
        public string TakeOffDateDt { get; set; }
        public string LandingDateDt { get; set; }

        public int Version { get; set; }
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }

        public string Date1Dt { get; set; }
        public string Date2Dt { get; set; }

    }


}
