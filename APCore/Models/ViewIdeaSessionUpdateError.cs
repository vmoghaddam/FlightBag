using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewIdeaSessionUpdateError
    {
        public int Id { get; set; }
        public int? SessionItemId { get; set; }
        public int? FDPId { get; set; }
        public int? EmployeeId { get; set; }
        public string Name { get; set; }
        public string Route { get; set; }
        public string Flights { get; set; }
        public DateTime? DutyStart { get; set; }
        public DateTime? DutyEnd { get; set; }
        public DateTime? RestUntil { get; set; }
        public DateTime? VisitDate { get; set; }
        public int IsVisited { get; set; }
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public DateTime? SessionDateFrom { get; set; }
        public DateTime? SessionDateTo { get; set; }
        public DateTime? DateCreate { get; set; }
    }
}
