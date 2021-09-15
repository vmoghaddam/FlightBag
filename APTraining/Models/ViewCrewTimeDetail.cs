using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class ViewCrewTimeDetail
    {
        public string PID { get; set; }
        public string JobGroupCode { get; set; }
        public int PersonId { get; set; }
        public int Id { get; set; }
        public DateTime? DateJoinCompany { get; set; }
        public int? ExpCompany { get; set; }
        public DateTime? DateRegister { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DateConfirmed { get; set; }
        public bool IsDeleted { get; set; }
        public string ImageUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? CustomerId { get; set; }
        public int? GroupId { get; set; }
        public string JobGroup { get; set; }
        public int MarriageId { get; set; }
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
        public string PassportNumber { get; set; }
        public DateTime? DatePassportIssue { get; set; }
        public DateTime? DatePassportExpire { get; set; }
        public string Address { get; set; }
        public DateTime? DateJoinAvation { get; set; }
        public int? Exp { get; set; }
        public DateTime? DateLastCheckUP { get; set; }
        public DateTime? DateNextCheckUP { get; set; }
        public DateTime? DateYearOfExperience { get; set; }
        public string CaoCardNumber { get; set; }
        public DateTime? DateCaoCardIssue { get; set; }
        public string CompetencyNo { get; set; }
        public int? CaoInterval { get; set; }
        public DateTime? DateCaoCardExpire { get; set; }
        public int? CurrentLocationAirportId { get; set; }
        public string CurrentLocationAirporIATA { get; set; }
        public int IsMedicalExpired { get; set; }
        public int IsAvSecExpired { get; set; }
        public int IsCCRMExpired { get; set; }
        public int IsCMCExpired { get; set; }
        public int IsColdWeatherExpired { get; set; }
        public int IsCRMExpired { get; set; }
        public int IsDGExpired { get; set; }
        public int IsHotWeatherExpired { get; set; }
        public int IsLicenceExpired { get; set; }
        public int IsLicenceIRExpired { get; set; }
        public int IsLPRExpired { get; set; }
        public int IsFirstAidExpired { get; set; }
        public int IsProficiencyExpired { get; set; }
        public int IsSEPTExpired { get; set; }
        public int IsSEPTPExpired { get; set; }
        public int IsSMSExpired { get; set; }
        public int IsUpsetRecoveryTrainingExpired { get; set; }
        public string ScheduleName { get; set; }
        public string Code { get; set; }
        public DateTime CDate { get; set; }
        public string DateStr { get; set; }
        public int Positioning { get; set; }
        public int CalendarStatusId { get; set; }
        public string CalendarStatus { get; set; }
        public double? Day1_Duty { get; set; }
        public double? Day7_Duty { get; set; }
        public double? Day14_Duty { get; set; }
        public double? Day28_Duty { get; set; }
        public int? Day1_Flight { get; set; }
        public int? Day7_Flight { get; set; }
        public int? Day14_Flight { get; set; }
        public int? Day28_Flight { get; set; }
        public int? Year_Flight { get; set; }
        public int? CYear_Flight { get; set; }
    }
}
