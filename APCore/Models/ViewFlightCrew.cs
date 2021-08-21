using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewFlightCrew
    {
        public int Id { get; set; }
        public int FlightInformationId { get; set; }
        public int? Status { get; set; }
        public string Remark { get; set; }
        public int? FlightPlanCrewId { get; set; }
        public int? EmployeeId { get; set; }
        public int? CalanderId { get; set; }
        public int? FlightPlanId { get; set; }
        public int? GroupId { get; set; }
        public string JobGroup { get; set; }
        public string JobGroupCode { get; set; }
        public string PID { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int? FlightStatusID { get; set; }
        public int? ActualFlightHOffBlock { get; set; }
        public decimal? ActualFlightMOffBlock { get; set; }
        public DateTime? ChocksOut { get; set; }
        public DateTime? ChocksIn { get; set; }
        public int? ActualFlightHTakeoff { get; set; }
        public decimal? ActualFlightMTakeoff { get; set; }
        public int? TotalFlightMinutesOffBlock { get; set; }
        public decimal? TotalFlightHoursOffBlock { get; set; }
        public decimal? PastHoursFromOffBlock { get; set; }
        public DateTime? ActualDateOffBlock { get; set; }
    }
}
