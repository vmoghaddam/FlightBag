using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class AcMsn
    {
        public AcMsn()
        {
            FlightInformations = new HashSet<FlightInformation>();
            FlightPlanItems = new HashSet<FlightPlanItem>();
            FlightPlanRegisterPlannedRegisters = new HashSet<FlightPlanRegister>();
            FlightPlanRegisterRegisters = new HashSet<FlightPlanRegister>();
        }

        public int Id { get; set; }
        public int? AcModelId { get; set; }
        public Guid? PkAircraftMsn { get; set; }
        public int? FkFlightRange { get; set; }
        public int AirlineOperatorsId { get; set; }
        public int? FkAcMsnStatus { get; set; }
        public int? Msn { get; set; }
        public string Register { get; set; }
        public int? TfhHours { get; set; }
        public byte? TfhMinutes { get; set; }
        public int? Tfc { get; set; }
        public DateTime? ManDate { get; set; }
        public DateTime? LastWb { get; set; }
        public bool? Etops { get; set; }
        public bool? AcFlag { get; set; }
        public int? CabinSeatVerF { get; set; }
        public int? CabinSeatVerB { get; set; }
        public int? CabinSeatVerC { get; set; }
        public int? CabinSeatVerR { get; set; }
        public int? LavQty { get; set; }
        public int? GalleyQty { get; set; }
        public int? CabinCrewVer { get; set; }
        public int? CockpitSeatVerPilot { get; set; }
        public int? CockpitSeatVerFlightEngineer { get; set; }
        public int? CockpitSeatVerObserver { get; set; }
        public string PreviousRegister { get; set; }
        public int? FuelLhOuter { get; set; }
        public int? FuelLhInner { get; set; }
        public int? FuelCenter { get; set; }
        public int? FuelRhInner { get; set; }
        public int? FuelRhOuter { get; set; }
        public int? FuelAct1 { get; set; }
        public int? FuelAct2 { get; set; }
        public int? FuelTrim { get; set; }
        public int? FuelTotal { get; set; }
        public bool? FuelUnit { get; set; }
        public int CustomerId { get; set; }
        public bool? IsVirtual { get; set; }
        public int? TypeId { get; set; }
        public int? TotalSeat { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }

        public virtual AircraftModel AcModel { get; set; }
        public virtual Organization AirlineOperators { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<FlightInformation> FlightInformations { get; set; }
        public virtual ICollection<FlightPlanItem> FlightPlanItems { get; set; }
        public virtual ICollection<FlightPlanRegister> FlightPlanRegisterPlannedRegisters { get; set; }
        public virtual ICollection<FlightPlanRegister> FlightPlanRegisterRegisters { get; set; }
    }
}
