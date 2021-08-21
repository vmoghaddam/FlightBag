using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewLegFuel
    {
        public int ID { get; set; }
        public int FlightId { get; set; }
        public int? FlightPlanId { get; set; }
        public byte? BlockM { get; set; }
        public int? BlockH { get; set; }
        public int? FlightH { get; set; }
        public byte? FlightM { get; set; }
        public DateTime? ChocksIn { get; set; }
        public DateTime? Landing { get; set; }
        public DateTime? Takeoff { get; set; }
        public DateTime? ChocksOut { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public DateTime? STDLocal { get; set; }
        public DateTime? STALocal { get; set; }
        public DateTime? Date { get; set; }
        public int? FlightStatusID { get; set; }
        public int? RegisterID { get; set; }
        public int? FlightTypeID { get; set; }
        public string AircraftType { get; set; }
        public int? TypeId { get; set; }
        public string FlightNumber { get; set; }
        public int? FromAirport { get; set; }
        public int? ToAirport { get; set; }
        public DateTime? STAPlanned { get; set; }
        public DateTime? STDPlanned { get; set; }
        public int? FlightHPlanned { get; set; }
        public int? FlightMPlanned { get; set; }
        public string FlightPlan { get; set; }
        public int? CustomerId { get; set; }
        public string FromAirportIATA { get; set; }
        public string ToAirportIATA { get; set; }
        public string Register { get; set; }
        public int? MSN { get; set; }
        public decimal? Defuel { get; set; }
        public decimal? FPFuel { get; set; }
        public decimal? FuelVariance { get; set; }
        public int? TotalPax { get; set; }
        public int? FuelUnitID { get; set; }
        public string FuelUnit { get; set; }
        public int? CargoUnitID { get; set; }
        public string CargoUnit { get; set; }
        public int? CargoCount { get; set; }
        public int? BaggageCount { get; set; }
        public string FlightStatus { get; set; }
        public string ArrivalRemark { get; set; }
        public string DepartureRemark { get; set; }
        public DateTime? STDDay { get; set; }
        public DateTime? STADay { get; set; }
        public int? DelayOffBlock { get; set; }
        public int? DelayTakeoff { get; set; }
        public int? DelayOnBlock { get; set; }
        public int? DelayLanding { get; set; }
        public int? IsDelayOffBlock { get; set; }
        public int? IsDelayTakeoff { get; set; }
        public int? IsDelayOnBlock { get; set; }
        public int? IsDelayLanding { get; set; }
        public int? ActualFlightHOffBlock { get; set; }
        public decimal? ActualFlightMOffBlock { get; set; }
        public int? ActualFlightHTakeoff { get; set; }
        public decimal? ActualFlightMTakeoff { get; set; }
        public DateTime? OSTA { get; set; }
        public int? OToAirportId { get; set; }
        public string OToAirportIATA { get; set; }
        public int? FPFlightHH { get; set; }
        public int? FPFlightMM { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? Arrival { get; set; }
        public DateTime? DepartureLocal { get; set; }
        public DateTime? ArrivalLocal { get; set; }
        public int? BlockTime { get; set; }
        public int? FlightTime { get; set; }
        public int? ScheduledFlightTime { get; set; }
        public int? FlightTimeActual { get; set; }
        public int? FixTime { get; set; }
        public int? SITATime { get; set; }
        public int? Duty { get; set; }
        public int? EstimatedDelay { get; set; }
        public int? status { get; set; }
        public decimal? duration { get; set; }
        public DateTime? startDate { get; set; }
        public string notes { get; set; }
        public int progress { get; set; }
        public string taskName { get; set; }
        public int taskId { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public DateTime? JLOffBlock { get; set; }
        public DateTime? JLOnBlock { get; set; }
        public DateTime? JLTakeOff { get; set; }
        public DateTime? JLLanding { get; set; }
        public int? PFLR { get; set; }
        public int? PaxChild { get; set; }
        public int? PaxInfant { get; set; }
        public int? PaxAdult { get; set; }
        public decimal? FuelArrival { get; set; }
        public decimal? FuelDeparture { get; set; }
        public decimal? UsedFuel { get; set; }
        public int? TotalSeat { get; set; }
        public int BaggageWeight { get; set; }
        public int CargoWeight { get; set; }
        public int? Freight { get; set; }
        public int? Weight { get; set; }
        public decimal? WeightTone { get; set; }
        public int? PaxWeight { get; set; }
        public decimal? PaxWeightTone { get; set; }
        public int? TotalPaxAll { get; set; }
    }
}
