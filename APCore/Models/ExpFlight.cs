using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ExpFlight
    {
        public string PersianDate { get; set; }
        public int? PersianYear { get; set; }
        public string PersianMonthName { get; set; }
        public int? PersianMonth { get; set; }
        public string PersianDayName { get; set; }
        public int? PersianDay { get; set; }
        public int Id { get; set; }
        public int? RegisterId { get; set; }
        public int? FlightStatusId { get; set; }
        public string AircraftType { get; set; }
        public int? AircraftTypeId { get; set; }
        public string FlightNo { get; set; }
        public int? OriginId { get; set; }
        public int? DestinationId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string OriginICAO { get; set; }
        public string DestinationICAO { get; set; }
        public string Register { get; set; }
        public string FlightStatus { get; set; }
        public DateTime? DepartureDay { get; set; }
        public DateTime? ArrivalDay { get; set; }
        public DateTime? DepartureDayLocal { get; set; }
        public DateTime? ArrivalDayLocal { get; set; }
        public int? BlockTime { get; set; }
        public int? FlightTime { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public DateTime? STDLocal { get; set; }
        public DateTime? STALocal { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? Arrival { get; set; }
        public DateTime? DepartureLocal { get; set; }
        public DateTime? ArrivalLocal { get; set; }
    }
}
