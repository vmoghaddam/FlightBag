using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewCourseSession
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime? DateStartUtc { get; set; }
        public DateTime? DateEndUtc { get; set; }
        public bool Done { get; set; }
        public string Remark { get; set; }
        public string Key { get; set; }
        public string DayName { get; set; }
        public int? Year { get; set; }
        public string MonthName { get; set; }
        public int? Month { get; set; }
        public string PDate { get; set; }
        public string PYearName { get; set; }
        public int? PYear { get; set; }
        public string PMonthName { get; set; }
        public int? PMonth { get; set; }
        public string PDayName { get; set; }
        public string No { get; set; }
        public string Instructor { get; set; }
        public string Title { get; set; }
        public string CT_Title { get; set; }
        public int? CustomerId { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public int? OrganizationId { get; set; }
        public string Organization { get; set; }
        public bool? IsGeneral { get; set; }
        public int? StatusId { get; set; }
        public string Status { get; set; }
    }
}
