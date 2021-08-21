using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewTrainingDuty
    {
        public int Id { get; set; }
        public DateTime? DateLocal { get; set; }
        public int? CrewId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public string ClassId { get; set; }
        public string JobGroup { get; set; }
        public string JobGroupCode { get; set; }
        public string ScheduleName { get; set; }
        public int IsCockpit { get; set; }
        public int IsCabin { get; set; }
        public DateTime? DutyStart { get; set; }
        public DateTime? DutyEnd { get; set; }
        public DateTime? DutyStartLocal { get; set; }
        public DateTime? DutyEndLocal { get; set; }
        public string Remark { get; set; }
        public DateTime? LocalDate { get; set; }
        public string PDate { get; set; }
        public string PYearName { get; set; }
        public int? PYear { get; set; }
        public string PMonthName { get; set; }
        public int? PMonth { get; set; }
        public string MonthName { get; set; }
        public string Month { get; set; }
        public string DayName { get; set; }
        public string YearName { get; set; }
    }
}
