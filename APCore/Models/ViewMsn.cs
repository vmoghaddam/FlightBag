using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewMSN
    {
        public int ID { get; set; }
        public int? AC_ModelID { get; set; }
        public int AirlineOperatorsID { get; set; }
        public int? MSN { get; set; }
        public string Register { get; set; }
        public int? TFH_Hours { get; set; }
        public byte? TFH_Minutes { get; set; }
        public int? TFC { get; set; }
        public DateTime? ManDate { get; set; }
        public DateTime? Last_WB { get; set; }
        public bool? ETOPS { get; set; }
        public bool? AC_Flag { get; set; }
        public int? Cabin_Seat_Ver_F { get; set; }
        public int? Cabin_Seat_Ver_B { get; set; }
        public int? Cabin_Seat_Ver_C { get; set; }
        public int? Cabin_Seat_Ver_R { get; set; }
        public int? Lav_QTY { get; set; }
        public int? Galley_QTY { get; set; }
        public int? Cabin_CrewVer { get; set; }
        public int? Cockpit_Seat_Ver_Pilot { get; set; }
        public int? Cockpit_Seat_Ver_FlightEngineer { get; set; }
        public int? Cockpit_Seat_Ver_Observer { get; set; }
        public string Previous_Register { get; set; }
        public int? Fuel_LH_Outer { get; set; }
        public int? Fuel_LH_Inner { get; set; }
        public int? Fuel_Center { get; set; }
        public int? Fuel_RH_Inner { get; set; }
        public int? Fuel_RH_Outer { get; set; }
        public int? Fuel_ACT2 { get; set; }
        public int? Fuel_ACT1 { get; set; }
        public int? Fuel_Trim { get; set; }
        public int? Fuel_Total { get; set; }
        public bool? FuelUnit { get; set; }
        public int CustomerId { get; set; }
        public string Model { get; set; }
        public int? AircraftTypeId { get; set; }
        public string AircraftType { get; set; }
        public int? ManufacturerId { get; set; }
        public string Manufacturer { get; set; }
        public string AirlineOperators { get; set; }
        public string Customer { get; set; }
        public bool? isvirtual { get; set; }
    }
}
