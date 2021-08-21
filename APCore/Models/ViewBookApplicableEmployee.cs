using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewBookApplicableEmployee
    {
        public int EmployeeId { get; set; }
        public int BookId { get; set; }
        public string PID { get; set; }
        public DateTime? DateJoinCompany { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? EmployeeCustomerId { get; set; }
        public int? GroupId { get; set; }
        public string JobGroup { get; set; }
        public string JobGroupCode { get; set; }
        public string NID { get; set; }
        public int SexId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public DateTime? DateBirth { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Mobile { get; set; }
        public string FaxTelNumber { get; set; }
        public DateTime? DateJoinAvation { get; set; }
        public DateTime? DateYearOfExperience { get; set; }
        public string CaoCardNumber { get; set; }
        public DateTime? DateCaoCardIssue { get; set; }
        public DateTime? DateCaoCardExpire { get; set; }
        public string CompetencyNo { get; set; }
        public int? CaoInterval { get; set; }
        public int? CaoIntervalCalanderTypeId { get; set; }
        public string StampNumber { get; set; }
        public string StampUrl { get; set; }
        public string TechLogNo { get; set; }
        public DateTime? DateIssueNDT { get; set; }
        public int? IntervalNDT { get; set; }
        public string NDTNumber { get; set; }
        public int? NDTIntervalCalanderTypeId { get; set; }
        public string IDNo { get; set; }
        public string EmployeeImageUrl { get; set; }
        public int? CustomerCreatorId { get; set; }
        public int? Age { get; set; }
        public string Sex { get; set; }
        public string CaoIntervalCalanderType { get; set; }
        public string NDTIntervalCalanderType { get; set; }
        public string Customer { get; set; }
        public int PersonId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime? DateRelease { get; set; }
        public int? PublisherId { get; set; }
        public string ISSNPrint { get; set; }
        public string ISSNElectronic { get; set; }
        public string DOI { get; set; }
        public string Pages { get; set; }
        public int CategoryId { get; set; }
        public int? CustomerId { get; set; }
        public string Category { get; set; }
        public string Publisher { get; set; }
        public string PublisherWebsite { get; set; }
        public DateTime? DateCreate { get; set; }
        public string Abstract { get; set; }
        public string ImageUrl { get; set; }
        public string Keywords { get; set; }
        public string AuthorIds { get; set; }
        public string Authors { get; set; }
        public string TranslatorIds { get; set; }
        public DateTime? DateExposure { get; set; }
        public int IsExposed { get; set; }
        public DateTime? DeadLine { get; set; }
        public DateTime? DateValidUntil { get; set; }
        public int? RemainingDeadLine { get; set; }
        public int? RemainingValid { get; set; }
        public bool? IsValid { get; set; }
        public bool? IsDownloaded { get; set; }
        public bool? IsVisited { get; set; }
        public DateTime? DateSigned { get; set; }
        public int IsSigned { get; set; }
        public DateTime? DateVisit { get; set; }
        public DateTime? DateDownload { get; set; }
        public string No { get; set; }
        public string Sender { get; set; }
        public string DateConference { get; set; }
        public int? ConferenceLocationId { get; set; }
        public string Conference { get; set; }
        public int? JournalId { get; set; }
        public int TypeId { get; set; }
        public int? NumberOfLessens { get; set; }
        public string ExternalUrl { get; set; }
        public string Duration { get; set; }
        public int? LanguageId { get; set; }
        public DateTime? DateDeadline { get; set; }
        public string Language { get; set; }
        public string Type { get; set; }
        public string Journal { get; set; }
        public string PublishedIn { get; set; }
        public string INSPECAccessionNumber { get; set; }
        public string DateEffective { get; set; }
        public string Edition { get; set; }
        public int? FolderId { get; set; }
        public string FolderCode { get; set; }
        public int? FileCount { get; set; }
        public string FileUrl { get; set; }
        public int? FileId { get; set; }
    }
}
