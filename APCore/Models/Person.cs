using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class Person
    {
        public Person()
        {
            CourseSessionPresences = new HashSet<CourseSessionPresence>();
            PersonAircraftTypes = new HashSet<PersonAircraftType>();
            PersonCaoLicenceHistories = new HashSet<PersonCaoLicenceHistory>();
            PersonCaoLicenses = new HashSet<PersonCaoLicense>();
            PersonCourses = new HashSet<PersonCourse>();
            PersonCustomers = new HashSet<PersonCustomer>();
            PersonDocuments = new HashSet<PersonDocument>();
            PersonEducations = new HashSet<PersonEducation>();
            PersonExperienses = new HashSet<PersonExperiense>();
            PersonRatings = new HashSet<PersonRating>();
        }

        public int Id { get; set; }
        public DateTime DateCreate { get; set; }
        public int MarriageId { get; set; }
        public string NID { get; set; }
        public int SexId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateBirth { get; set; }
        public string Email { get; set; }
        public string EmailPassword { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Mobile { get; set; }
        public string FaxTelNumber { get; set; }
        public string PassportNumber { get; set; }
        public DateTime? DatePassportIssue { get; set; }
        public DateTime? DatePassportExpire { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DateJoinAvation { get; set; }
        public DateTime? DateLastCheckUP { get; set; }
        public DateTime? DateNextCheckUP { get; set; }
        public DateTime? DateYearOfExperience { get; set; }
        public string CaoCardNumber { get; set; }
        public DateTime? DateCaoCardIssue { get; set; }
        public DateTime? DateCaoCardExpire { get; set; }
        public string CompetencyNo { get; set; }
        public int? CaoInterval { get; set; }
        public int? CaoIntervalCalanderTypeId { get; set; }
        public bool IsDeleted { get; set; }
        public string Remark { get; set; }
        public string StampNumber { get; set; }
        public string StampUrl { get; set; }
        public string TechLogNo { get; set; }
        public DateTime? DateIssueNDT { get; set; }
        public int? IntervalNDT { get; set; }
        public string NDTNumber { get; set; }
        public int? NDTIntervalCalanderTypeId { get; set; }
        public bool? IsAuditor { get; set; }
        public bool? IsAuditee { get; set; }
        public string Nickname { get; set; }
        public int? CityId { get; set; }
        public string FatherName { get; set; }
        public string IDNo { get; set; }
        public Guid? RowId { get; set; }
        public string UserId { get; set; }
        public string ImageUrl { get; set; }
        public int? CustomerCreatorId { get; set; }
        public DateTime? DateExpireNDT { get; set; }
        public DateTime? ProficiencyExpireDate { get; set; }
        public DateTime? CrewMemberCertificateExpireDate { get; set; }
        public DateTime? LicenceExpireDate { get; set; }
        public DateTime? SimulatorLastCheck { get; set; }
        public DateTime? SimulatorNextCheck { get; set; }
        public string RampPassNo { get; set; }
        public DateTime? RampPassExpireDate { get; set; }
        public DateTime? LanguageCourseExpireDate { get; set; }
        public string LicenceTitle { get; set; }
        public DateTime? LicenceInitialIssue { get; set; }
        public string RaitingCertificates { get; set; }
        public DateTime? LicenceIssueDate { get; set; }
        public string LicenceDescription { get; set; }
        public int? ProficiencyCheckType { get; set; }
        public DateTime? ProficiencyCheckDate { get; set; }
        public DateTime? ProficiencyValidUntil { get; set; }
        public int? ICAOLPRLevel { get; set; }
        public DateTime? ICAOLPRValidUntil { get; set; }
        public int? MedicalClass { get; set; }
        public string CMCEmployedBy { get; set; }
        public string CMCOccupation { get; set; }
        public string PostalCode { get; set; }
        public bool? ProficiencyIPC { get; set; }
        public bool? ProficiencyOPC { get; set; }
        public string MedicalLimitation { get; set; }
        public string ProficiencyDescription { get; set; }
        public DateTime? VisaExpireDate { get; set; }
        public DateTime? SEPTIssueDate { get; set; }
        public DateTime? SEPTExpireDate { get; set; }
        public DateTime? DangerousGoodsIssueDate { get; set; }
        public DateTime? DangerousGoodsExpireDate { get; set; }
        public DateTime? CCRMIssueDate { get; set; }
        public DateTime? CCRMExpireDate { get; set; }
        public DateTime? CRMIssueDate { get; set; }
        public DateTime? CRMExpireDate { get; set; }
        public DateTime? SMSIssueDate { get; set; }
        public DateTime? SMSExpireDate { get; set; }
        public DateTime? AviationSecurityIssueDate { get; set; }
        public DateTime? AviationSecurityExpireDate { get; set; }
        public DateTime? EGPWSIssueDate { get; set; }
        public DateTime? EGPWSExpireDate { get; set; }
        public DateTime? UpsetRecoveryTrainingIssueDate { get; set; }
        public DateTime? UpsetRecoveryTrainingExpireDate { get; set; }
        public DateTime? ColdWeatherOperationIssueDate { get; set; }
        public DateTime? HotWeatherOperationIssueDate { get; set; }
        public DateTime? PBNRNAVIssueDate { get; set; }
        public DateTime? PBNRNAVExpireDate { get; set; }
        public DateTime? ColdWeatherOperationExpireDate { get; set; }
        public DateTime? HotWeatherOperationExpireDate { get; set; }
        public string ScheduleName { get; set; }
        public string Code { get; set; }
        public DateTime? SEPTPIssueDate { get; set; }
        public DateTime? SEPTPExpireDate { get; set; }
        public DateTime? FirstAidIssueDate { get; set; }
        public DateTime? FirstAidExpireDate { get; set; }
        public DateTime? LicenceIRExpireDate { get; set; }
        public int? RankId { get; set; }
        public string LinkedIn { get; set; }
        public string WhatsApp { get; set; }
        public string Telegram { get; set; }
        public int? AircraftTypeId { get; set; }
        public DateTime? DateTypeIssue { get; set; }
        public DateTime? DateTypeExpire { get; set; }
        public string ProficiencyDescriptionOPC { get; set; }
        public DateTime? ProficiencyCheckDateOPC { get; set; }
        public DateTime? ProficiencyValidUntilOPC { get; set; }
        public DateTime? DateTRIExpired { get; set; }
        public DateTime? DateTREExpired { get; set; }
        public DateTime? LineIssueDate { get; set; }
        public DateTime? LineExpireDate { get; set; }
        public DateTime? RecurrentIssueDate { get; set; }
        public DateTime? RecurrentExpireDate { get; set; }

        public virtual Option CaoIntervalCalanderType { get; set; }
        public virtual Option Marriage { get; set; }
        public virtual Option NDTIntervalCalanderType { get; set; }
        public virtual ICollection<CourseSessionPresence> CourseSessionPresences { get; set; }
        public virtual ICollection<PersonAircraftType> PersonAircraftTypes { get; set; }
        public virtual ICollection<PersonCaoLicenceHistory> PersonCaoLicenceHistories { get; set; }
        public virtual ICollection<PersonCaoLicense> PersonCaoLicenses { get; set; }
        public virtual ICollection<PersonCourse> PersonCourses { get; set; }
        public virtual ICollection<PersonCustomer> PersonCustomers { get; set; }
        public virtual ICollection<PersonDocument> PersonDocuments { get; set; }
        public virtual ICollection<PersonEducation> PersonEducations { get; set; }
        public virtual ICollection<PersonExperiense> PersonExperienses { get; set; }
        public virtual ICollection<PersonRating> PersonRatings { get; set; }
    }
}
