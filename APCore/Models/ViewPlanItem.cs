using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewPlanItem
    {
        public int Id { get; set; }
        public int taskId { get; set; }
        public DateTime? DateFrom { get; set; }
        public string Day { get; set; }
        public int FromAirport { get; set; }
        public int ToAirport { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public DateTime Dep { get; set; }
        public DateTime startDateUTC { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime Arr { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public int TypeId { get; set; }
        public string AircraftType { get; set; }
        public DateTime? DateTo { get; set; }
        public string FlightNumber { get; set; }
        public string FromAirportIATA { get; set; }
        public string ToAirportIATA { get; set; }
        public int progress { get; set; }
        public decimal? duration { get; set; }
        public int EstimatedDelay { get; set; }
        public int DelayOffBlock { get; set; }
        public int DelayTakeoff { get; set; }
        public int DelayOnBlock { get; set; }
        public int DelayLanding { get; set; }
        public int IsDelayOffBlock { get; set; }
        public int IsDelayTakeoff { get; set; }
        public int IsDelayOnBlock { get; set; }
        public int IsDelayLanding { get; set; }
        public int? FlightH { get; set; }
        public int? FlightM { get; set; }
        public string Line { get; set; }
    }
}
