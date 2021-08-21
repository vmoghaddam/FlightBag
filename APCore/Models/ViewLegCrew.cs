using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewLegCrew
    {
        public int? CrewId { get; set; }
        public int? FlightId { get; set; }
        public int FDPId { get; set; }
        public int FDPItemId { get; set; }
        public bool? IsPositioning { get; set; }
        public int? PositionId { get; set; }
        public string Position { get; set; }
        public string Name { get; set; }
        public string ScheduleName { get; set; }
        public int? GroupId { get; set; }
        public string JobGroup { get; set; }
        public string JobGroupCode { get; set; }
        public int? GroupOrder { get; set; }
        public int IsCockpit { get; set; }
        public int? FlightPlanId { get; set; }
        public byte? BlockM { get; set; }
        public int? BlockH { get; set; }
        public int? FlightH { get; set; }
        public byte? FlightM { get; set; }
        public DateTime? ChocksIn { get; set; }
        public DateTime? Landing { get; set; }
        public int? Duty { get; set; }
        public int? ScheduledFlightTime { get; set; }
        public int? SITATime { get; set; }
        public int? FixTime { get; set; }
        public int? FlightTimeActual { get; set; }
        public int? FlightTime { get; set; }
        public int? BlockTime { get; set; }
        public DateTime? ArrivalLocal { get; set; }
        public DateTime? DepartureLocal { get; set; }
        public DateTime? Arrival { get; set; }
        public DateTime? Departure { get; set; }
        public int? FPFlightMM { get; set; }
        public int? FPFlightHH { get; set; }
        public string OToAirportIATA { get; set; }
        public int? OToAirportId { get; set; }
        public DateTime? OSTA { get; set; }
        public decimal? ActualFlightMTakeoff { get; set; }
        public int? ActualFlightHTakeoff { get; set; }
        public decimal? ActualFlightMOffBlock { get; set; }
        public int? ActualFlightHOffBlock { get; set; }
        public int? IsDelayLanding { get; set; }
        public int? IsDelayOnBlock { get; set; }
        public int? IsDelayTakeoff { get; set; }
        public int? IsDelayOffBlock { get; set; }
        public int? DelayLanding { get; set; }
        public int? DelayOnBlock { get; set; }
        public int? DelayTakeoff { get; set; }
        public int? DelayOffBlock { get; set; }
        public DateTime? STADay { get; set; }
        public DateTime? STDDay { get; set; }
        public string ArrivalRemark { get; set; }
        public string FlightStatus { get; set; }
        public string Register { get; set; }
        public string ToAirportIATA { get; set; }
        public int? MSN { get; set; }
        public string DepartureRemark { get; set; }
        public string FromAirportIATA { get; set; }
        public int? CustomerId { get; set; }
        public string FlightPlan { get; set; }
        public int? FlightMPlanned { get; set; }
        public int? FlightHPlanned { get; set; }
        public DateTime? STDPlanned { get; set; }
        public DateTime? STAPlanned { get; set; }
        public int? ToAirport { get; set; }
        public int? FromAirport { get; set; }
        public string FlightNumber { get; set; }
        public int? FlightTypeID { get; set; }
        public int? RegisterID { get; set; }
        public int? FlightStatusID { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? STALocal { get; set; }
        public DateTime? STDLocal { get; set; }
        public DateTime? STA { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? ChocksOut { get; set; }
        public DateTime? Takeoff { get; set; }
    }
}
