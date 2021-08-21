using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewPersonActiveCourse
    {
        public int CourseId { get; set; }
        public int PersonId { get; set; }
        public string No { get; set; }
        public int CourseTypeId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string Instructor { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public int? OrganizationId { get; set; }
        public int? Duration { get; set; }
        public int? DurationUnitId { get; set; }
        public string CourseRemark { get; set; }
        public int? Capacity { get; set; }
        public int? Tuition { get; set; }
        public int? CurrencyId { get; set; }
        public int? CourseStatusId { get; set; }
        public DateTime? DateDeadlineRegistration { get; set; }
        public string TrainingDirector { get; set; }
        public string Title { get; set; }
        public bool? Recurrent { get; set; }
        public int? Interval { get; set; }
        public int? CalanderTypeId { get; set; }
        public bool? IsInside { get; set; }
        public bool? Quarantine { get; set; }
        public DateTime? DateStartPractical { get; set; }
        public DateTime? DateEndPractical { get; set; }
        public int? DurationPractical { get; set; }
        public int? DurationPracticalUnitId { get; set; }
        public int? CT_CalendarTypeId { get; set; }
        public string CT_Title { get; set; }
        public int? CT_LicenseResultBasicId { get; set; }
        public string CT_Remark { get; set; }
        public int? CT_CourseCategoryId { get; set; }
        public int? CT_Interval { get; set; }
        public bool? CT_IsGeneral { get; set; }
        public bool? CT_Status { get; set; }
        public int? CT_Id { get; set; }
        public string CC_Title { get; set; }
        public string CaoTypeTitle { get; set; }
        public string CaoTypeRemark { get; set; }
        public string Organization { get; set; }
        public string DurationUnit { get; set; }
        public string Duration2 { get; set; }
        public string Currency { get; set; }
        public string CalendarType { get; set; }
        public string DurationPracticalUnit { get; set; }
        public int? Remain { get; set; }
        public DateTime? ExpireDate { get; set; }
        public bool? IsGeneral { get; set; }
        public int? CourseCustomerId { get; set; }
        public string CerNumber { get; set; }
        public string Remark { get; set; }
        public DateTime? DateIssue { get; set; }
        public DateTime? DateStatus { get; set; }
        public bool? StatusConfirmed { get; set; }
        public int? StatusId { get; set; }
        public string Status { get; set; }
        public string CourseStatus { get; set; }
    }
}
