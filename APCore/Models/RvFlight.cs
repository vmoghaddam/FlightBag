using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class RvFlight
    {
        public string DateUtc { get; set; }
        public string FltNo { get; set; }
        public string DepStn { get; set; }
        public string ArrStn { get; set; }
        public string Actype { get; set; }
        public string Acreg { get; set; }
        public string Std { get; set; }
        public string Sta { get; set; }
        public string Atd { get; set; }
        public string Ata { get; set; }
        public string OffBlock { get; set; }
        public string OnBlock { get; set; }
        public string TakeOff { get; set; }
        public string OnRunway { get; set; }
        public string SaveTime { get; set; }
        public string Male { get; set; }
        public string Female { get; set; }
        public string PaxAdl { get; set; }
        public string PaxChd { get; set; }
        public string PaxInf { get; set; }
        public string TotalSeats { get; set; }
        public string OverPax { get; set; }
        public string FuelRemain { get; set; }
        public string FuelUpLift { get; set; }
        public string FuelDefuel { get; set; }
        public string FuelTotal { get; set; }
        public string FuelTaxi { get; set; }
        public string FuelTrip { get; set; }
        public string FuelUnit { get; set; }
        public string CargoWeight { get; set; }
        public string CargoPiece { get; set; }
        public string Baggage { get; set; }
        public string BagPiece { get; set; }
        public string Tag1 { get; set; }
        public string Tag2 { get; set; }
        public string Tag3 { get; set; }
        public string Parking { get; set; }
        public string Paxstation { get; set; }
        public string StationIncomeCurrency { get; set; }
        public string AlternateStation { get; set; }
        public string Status { get; set; }
    }
}
