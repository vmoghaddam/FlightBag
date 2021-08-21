using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewCrewValid
    {
        public int Id { get; set; }
        public int SexId { get; set; }
        public string PID { get; set; }
        public int PersonId { get; set; }
        public int? CustomerId { get; set; }
        public int? GroupId { get; set; }
        public string JobGroup { get; set; }
        public string JobGroupCode { get; set; }
        public string Position { get; set; }
        public int PositionId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public int? CurrentLocationAirportId { get; set; }
        public string CurrentLocationAirporIATA { get; set; }
        public string CurrentLocationCity { get; set; }
        public int? CurrentLocationCityId { get; set; }
        public int? LastLocationId { get; set; }
        public string LastLocation { get; set; }
        public string ScheduleName { get; set; }
        public string Code { get; set; }
        public string ValidationMessage { get; set; }
        public int Flight { get; set; }
        public int GroupOrder { get; set; }
        public DateTime DateInactiveBegin { get; set; }
        public DateTime DateInactiveEnd { get; set; }
        public int? StandById { get; set; }
        public int? AircraftTypeId { get; set; }
        public DateTime? DateTypeIssue { get; set; }
        public DateTime? DateTypeExpire { get; set; }
        public string ValidTypes { get; set; }
        public double FlightSum { get; set; }
        public int FlightEarly { get; set; }
        public int FlightLate { get; set; }
    }
}
