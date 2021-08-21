using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewFlightPlanItem
    {
        public int Id { get; set; }
        public int taskID { get; set; }
        public int FlightPlanId { get; set; }
        public int? TypeId { get; set; }
        public int RegisterID { get; set; }
        public int? FlightTypeID { get; set; }
        public string FlightType { get; set; }
        public int? AirlineOperatorsID { get; set; }
        public string FlightNumber { get; set; }
        public int FromAirport { get; set; }
        public int ToAirport { get; set; }
        public DateTime? STA { get; set; }
        public DateTime? STD { get; set; }
        public int FlightH { get; set; }
        public int FlightM { get; set; }
        public string Unknown { get; set; }
        public string FlightPlan { get; set; }
        public int CustomerId { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DateActive { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Customer { get; set; }
        public string FromAirportName { get; set; }
        public string FromAirportIATA { get; set; }
        public string from { get; set; }
        public int? FromAirportCityId { get; set; }
        public string ToAirportName { get; set; }
        public string ToAirportIATA { get; set; }
        public string to { get; set; }
        public int? ToAirportCityId { get; set; }
        public int? BaseId { get; set; }
        public string BaseName { get; set; }
        public string BaseIATA { get; set; }
        public string notes { get; set; }
        public int? status { get; set; }
        public int progress { get; set; }
        public decimal? duration { get; set; }
        public DateTime? startDate { get; set; }
        public string taskName { get; set; }
        public string FromAirportCity { get; set; }
        public string ToAirportCity { get; set; }
        public int? MSN { get; set; }
        public string Register { get; set; }
        public string AircraftType { get; set; }
        public string FlightStatus { get; set; }
        public int? StatusId { get; set; }
        public string FromCity { get; set; }
        public string FromContry { get; set; }
        public string FromSortName { get; set; }
        public string ToCity { get; set; }
        public string ToSortName { get; set; }
        public string ToCountry { get; set; }
        public string Manufacturer { get; set; }
        public int? ManufacturerId { get; set; }
        public decimal? ToLatitude { get; set; }
        public decimal? ToLongitude { get; set; }
        public decimal? FromLatitude { get; set; }
        public decimal? FromLongitude { get; set; }
        public int? RouteId { get; set; }
        public int IsApproved100 { get; set; }
        public int IsApproved50 { get; set; }
        public int IsApproved60 { get; set; }
        public int IsApproved70 { get; set; }
        public int IsApproved80 { get; set; }
        public int IsApproved90 { get; set; }
        public int? Interval { get; set; }
        public string IntervalType { get; set; }
        public int? BoxId { get; set; }
        public int AssignedCrewCount { get; set; }
        public int AssignedCrewProblemCount { get; set; }
        public string DepartureRemark { get; set; }
    }
}
