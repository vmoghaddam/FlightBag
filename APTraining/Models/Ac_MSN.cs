using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class Ac_MSN
    {
        public Ac_MSN()
        {
            FlightInformations = new HashSet<FlightInformation>();
            FlightPlanItems = new HashSet<FlightPlanItem>();
            FlightPlanRegisterPlannedRegisters = new HashSet<FlightPlanRegister>();
            FlightPlanRegisterRegisters = new HashSet<FlightPlanRegister>();
        }

        public int ID { get; set; }
        public int? AC_ModelID { get; set; }
        public Guid? pkAircraftMSN { get; set; }
        public int? fkFlight_Range { get; set; }
        public int AirlineOperatorsID { get; set; }
        public int? fkAc_MSN_Status { get; set; }
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
        public int? Fuel_ACT1 { get; set; }
        public int? Fuel_ACT2 { get; set; }
        public int? Fuel_Trim { get; set; }
        public int? Fuel_Total { get; set; }
        public bool? FuelUnit { get; set; }
        public int CustomerId { get; set; }
        public bool? IsVirtual { get; set; }
        public int? TypeId { get; set; }
        public int? TotalSeat { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }

        public virtual AircraftModel AC_Model { get; set; }
        public virtual Organization AirlineOperators { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<FlightInformation> FlightInformations { get; set; }
        public virtual ICollection<FlightPlanItem> FlightPlanItems { get; set; }
        public virtual ICollection<FlightPlanRegister> FlightPlanRegisterPlannedRegisters { get; set; }
        public virtual ICollection<FlightPlanRegister> FlightPlanRegisterRegisters { get; set; }
    }
}
