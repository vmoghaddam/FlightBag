using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewCertificate
    {
        public string CourseNo { get; set; }
        public DateTime CourseDateStart { get; set; }
        public string CourseInstructor { get; set; }
        public string CourseTitle { get; set; }
        public string CourseTrainingDirector { get; set; }
        public bool? CourseRecurrent { get; set; }
        public int? CourseInterval { get; set; }
        public int? CourseCalanderTypeId { get; set; }
        public int CourseTypeId { get; set; }
        public string CourseLocation { get; set; }
        public string CourseDepartment { get; set; }
        public int? CourseOrganizationId { get; set; }
        public int? CourseDurationUnitId { get; set; }
        public int? CourseDuration { get; set; }
        public string CourseRemark { get; set; }
        public string CourseTypeTitle { get; set; }
        public string CourseCategoryTitle { get; set; }
        public string CaoTypeTitle { get; set; }
        public int? CaoTypeId { get; set; }
        public string CourseOrganization { get; set; }
        public string CourseDurationUnit { get; set; }
        public string CourseDuration2 { get; set; }
        public string CourseCalendarType { get; set; }
        public int? CourseCustomerId { get; set; }
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int? StatusId { get; set; }
        public string Remark { get; set; }
        public int? CourseId { get; set; }
        public string CerNumber { get; set; }
        public DateTime? DateIssue { get; set; }
        public DateTime? DateExpire { get; set; }
        public string CerUrl { get; set; }
        public DateTime? DateStatus { get; set; }
        public bool? StatusConfirmed { get; set; }
        public string PID { get; set; }
        public DateTime? DateJoinCompany { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? CustomerId { get; set; }
        public int? GroupId { get; set; }
        public string JobGroup { get; set; }
        public string JobGroupCode { get; set; }
        public string NID { get; set; }
        public int SexId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Mobile { get; set; }
        public string FaxTelNumber { get; set; }
        public DateTime? DateJoinAvation { get; set; }
        public string CaoCardNumber { get; set; }
        public DateTime? DateCaoCardIssue { get; set; }
        public DateTime? DateCaoCardExpire { get; set; }
        public string CompetencyNo { get; set; }
        public int? CaoInterval { get; set; }
        public int? CaoIntervalCalanderTypeId { get; set; }
        public string StampUrl { get; set; }
        public string StampNumber { get; set; }
        public string TechLogNo { get; set; }
        public DateTime? DateIssueNDT { get; set; }
        public int? IntervalNDT { get; set; }
        public string NDTNumber { get; set; }
        public int? NDTIntervalCalanderTypeId { get; set; }
        public string IDNo { get; set; }
        public int? CustomerCreatorId { get; set; }
        public int? Age { get; set; }
        public string Sex { get; set; }
        public string CaoIntervalCalanderType { get; set; }
        public string NDTIntervalCalanderType { get; set; }
        public string Customer { get; set; }
        public DateTime? DateEnd { get; set; }
        public int? Remain { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int? ExpireStatus { get; set; }
        public long? RankLast { get; set; }
        public long? RankFirst { get; set; }
        public int IsLast { get; set; }
        public int IsFirst { get; set; }
        public bool? IsNotificationEnabled { get; set; }
    }
}
