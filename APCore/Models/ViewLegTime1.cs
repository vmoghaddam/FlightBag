using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewLegTime1
    {
        public int Id { get; set; }
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
        public DateTime? Std { get; set; }
        public DateTime? Sta { get; set; }
        public DateTime? Stdlocal { get; set; }
        public DateTime? Stalocal { get; set; }
        public DateTime? Date { get; set; }
        public int? FlightStatusId { get; set; }
        public int? RegisterId { get; set; }
        public int? FlightTypeId { get; set; }
        public string AircraftType { get; set; }
        public int? TypeId { get; set; }
        public string FlightNumber { get; set; }
        public int? FromAirport { get; set; }
        public int? ToAirport { get; set; }
        public DateTime? Staplanned { get; set; }
        public DateTime? Stdplanned { get; set; }
        public int? FlightHplanned { get; set; }
        public int? FlightMplanned { get; set; }
        public string FlightPlan { get; set; }
        public int? CustomerId { get; set; }
        public string FromAirportIata { get; set; }
        public string ToAirportIata { get; set; }
        public string Register { get; set; }
        public int? Msn { get; set; }
        public string FlightStatus { get; set; }
        public string ArrivalRemark { get; set; }
        public string DepartureRemark { get; set; }
        public DateTime? Stdday { get; set; }
        public DateTime? Staday { get; set; }
        public int? DelayOffBlock { get; set; }
        public int? DelayTakeoff { get; set; }
        public int? DelayOnBlock { get; set; }
        public int? DelayLanding { get; set; }
        public int? IsDelayOffBlock { get; set; }
        public int? IsDelayTakeoff { get; set; }
        public int? IsDelayOnBlock { get; set; }
        public int? IsDelayLanding { get; set; }
        public int? ActualFlightHoffBlock { get; set; }
        public decimal? ActualFlightMoffBlock { get; set; }
        public int? ActualFlightHtakeoff { get; set; }
        public decimal? ActualFlightMtakeoff { get; set; }
        public DateTime? Osta { get; set; }
        public int? OtoAirportId { get; set; }
        public string OtoAirportIata { get; set; }
        public int? FpflightHh { get; set; }
        public int? FpflightMm { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? Arrival { get; set; }
        public DateTime? DepartureLocal { get; set; }
        public DateTime? ArrivalLocal { get; set; }
        public int? BlockTime { get; set; }
        public int? FlightTime { get; set; }
        public int? ScheduledFlightTime { get; set; }
        public int? FlightTimeActual { get; set; }
        public int? FixTime { get; set; }
        public int? Sitatime { get; set; }
        public int? Duty { get; set; }
        public int? EstimatedDelay { get; set; }
        public int? Status { get; set; }
        public decimal? Duration { get; set; }
        public DateTime? StartDate { get; set; }
        public string Notes { get; set; }
        public int Progress { get; set; }
        public string TaskName { get; set; }
        public int TaskId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime? JloffBlock { get; set; }
        public DateTime? JlonBlock { get; set; }
        public DateTime? JltakeOff { get; set; }
        public DateTime? Jllanding { get; set; }
        public int? Pflr { get; set; }
        public int? PaxChild { get; set; }
        public int? PaxInfant { get; set; }
        public int? PaxAdult { get; set; }
        public int? FuelUnitId { get; set; }
        public decimal? FuelArrival { get; set; }
        public decimal? FuelDeparture { get; set; }
        public decimal? UsedFuel { get; set; }
        public int? TotalSeat { get; set; }
        public int BaggageWeight { get; set; }
        public int CargoWeight { get; set; }
        public int? Freight { get; set; }
        public DateTime? FlightDate { get; set; }
        public int? CargoCount { get; set; }
        public int? BaggageCount { get; set; }
        public int? JlblockTime { get; set; }
        public int? JlflightTime { get; set; }
        public decimal? Fpfuel { get; set; }
    }
}
