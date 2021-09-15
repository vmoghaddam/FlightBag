using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class Course
    {
        public Course()
        {
            CourseAircraftTypes = new HashSet<CourseAircraftType>();
            CourseCatRates = new HashSet<CourseCatRate>();
            CoursePeople = new HashSet<CoursePerson>();
            CourseRelatedAircraftTypes = new HashSet<CourseRelatedAircraftType>();
            CourseRelatedCourseCourses = new HashSet<CourseRelatedCourse>();
            CourseRelatedCourseRelatedCourses = new HashSet<CourseRelatedCourse>();
            CourseRelatedCourseTypes = new HashSet<CourseRelatedCourseType>();
            CourseRelatedEmployees = new HashSet<CourseRelatedEmployee>();
            CourseRelatedGroups = new HashSet<CourseRelatedGroup>();
            CourseRelatedStudyFields = new HashSet<CourseRelatedStudyField>();
            CourseSessionFDPs = new HashSet<CourseSessionFDP>();
            CourseSessionPresences = new HashSet<CourseSessionPresence>();
            CourseSessions = new HashSet<CourseSession>();
            PersonCourses = new HashSet<PersonCourse>();
        }

        public int Id { get; set; }
        public int CourseTypeId { get; set; }
        public DateTime DateStart { get; set; }
        public decimal? DateStartP { get; set; }
        public DateTime? DateEnd { get; set; }
        public decimal? DateEndP { get; set; }
        public string Instructor { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public int? OrganizationId { get; set; }
        public int? Duration { get; set; }
        public int? DurationUnitId { get; set; }
        public int? StatusId { get; set; }
        public string Remark { get; set; }
        public int? Capacity { get; set; }
        public int? Tuition { get; set; }
        public int? CurrencyId { get; set; }
        public DateTime? DateDeadlineRegistration { get; set; }
        public decimal? DateDeadlineRegistrationP { get; set; }
        public string TrainingDirector { get; set; }
        public string Title { get; set; }
        public int? AircraftTypeId { get; set; }
        public int? AircraftModelId { get; set; }
        public int? CaoTypeId { get; set; }
        public bool? Recurrent { get; set; }
        public int? Interval { get; set; }
        public int? CalanderTypeId { get; set; }
        public bool? IsInside { get; set; }
        public bool? Quarantine { get; set; }
        public DateTime? DateStartPractical { get; set; }
        public DateTime? DateEndPractical { get; set; }
        public decimal? DateStartPracticalP { get; set; }
        public decimal? DateEndPracticalP { get; set; }
        public int? DurationPractical { get; set; }
        public int? DurationPracticalUnitId { get; set; }
        public bool? IsGeneral { get; set; }
        public int? CustomerId { get; set; }
        public string No { get; set; }
        public bool? IsNotificationEnabled { get; set; }

        public virtual AircraftModel AircraftModel { get; set; }
        public virtual AircraftType AircraftType { get; set; }
        public virtual CaoType CaoType { get; set; }
        public virtual CourseType CourseType { get; set; }
        public virtual ICollection<CourseAircraftType> CourseAircraftTypes { get; set; }
        public virtual ICollection<CourseCatRate> CourseCatRates { get; set; }
        public virtual ICollection<CoursePerson> CoursePeople { get; set; }
        public virtual ICollection<CourseRelatedAircraftType> CourseRelatedAircraftTypes { get; set; }
        public virtual ICollection<CourseRelatedCourse> CourseRelatedCourseCourses { get; set; }
        public virtual ICollection<CourseRelatedCourse> CourseRelatedCourseRelatedCourses { get; set; }
        public virtual ICollection<CourseRelatedCourseType> CourseRelatedCourseTypes { get; set; }
        public virtual ICollection<CourseRelatedEmployee> CourseRelatedEmployees { get; set; }
        public virtual ICollection<CourseRelatedGroup> CourseRelatedGroups { get; set; }
        public virtual ICollection<CourseRelatedStudyField> CourseRelatedStudyFields { get; set; }
        public virtual ICollection<CourseSessionFDP> CourseSessionFDPs { get; set; }
        public virtual ICollection<CourseSessionPresence> CourseSessionPresences { get; set; }
        public virtual ICollection<CourseSession> CourseSessions { get; set; }
        public virtual ICollection<PersonCourse> PersonCourses { get; set; }
    }
}
