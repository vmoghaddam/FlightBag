using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class RptFDP
    {
        public int FDPId { get; set; }
        public int? CrewId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ScheduleName { get; set; }
        public string JobGroup { get; set; }
        public string JobGroupCode { get; set; }
        public string JobGroupRoot { get; set; }
        public DateTime? STDDay { get; set; }
        public DateTime? STADay { get; set; }
        public DateTime? STDDayUTC { get; set; }
        public DateTime? STADayUTC { get; set; }
        public string Flights { get; set; }
        public string Route { get; set; }
        public int? Legs { get; set; }
        public int? FlightTime { get; set; }
        public int? BlockTime { get; set; }
        public int? ScheduledTime { get; set; }
        public TimeSpan? FixTime2 { get; set; }
        public int? FixTime { get; set; }
        public string DayName { get; set; }
        public string PDayName { get; set; }
        public int? Year { get; set; }
        public int? PYear { get; set; }
        public string MonthName { get; set; }
        public string PMonthName { get; set; }
        public int? Month { get; set; }
        public int? PMonth { get; set; }
        public string PDate { get; set; }
        public string PeriodFixTime { get; set; }
        public int Leg1 { get; set; }
        public int Leg2 { get; set; }
        public int Leg3 { get; set; }
        public int Leg4 { get; set; }
        public int Leg5 { get; set; }
        public int Leg6 { get; set; }
        public int Leg7 { get; set; }
        public int Leg8 { get; set; }
    }
}
