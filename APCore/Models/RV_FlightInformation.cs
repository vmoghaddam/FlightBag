using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class RV_FlightInformation
    {
        public string DateUTC { get; set; }
        public string FltNo { get; set; }
        public string DepStn { get; set; }
        public string ArrStn { get; set; }
        public string ACType { get; set; }
        public string ACReg { get; set; }
        public string STD { get; set; }
        public string STA { get; set; }
        public string ATD { get; set; }
        public string ATA { get; set; }
        public string OffBlock { get; set; }
        public string OnBlock { get; set; }
        public string TakeOff { get; set; }
        public string OnRunway { get; set; }
        public string SaveTime { get; set; }
        public string Male { get; set; }
        public string Female { get; set; }
        public string PaxADL { get; set; }
        public string PaxCHD { get; set; }
        public string PaxINF { get; set; }
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
        public string PAXStation { get; set; }
        public string StationIncomeCurrency { get; set; }
        public string AlternateStation { get; set; }
        public string Status { get; set; }
    }
}
