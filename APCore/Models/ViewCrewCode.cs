using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewCrewCode
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string PID { get; set; }
        public int PersonId { get; set; }
        public DateTime? DateJoinCompany { get; set; }
        public int? ExpCompany { get; set; }
        public DateTime? DateRegister { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DateConfirmed { get; set; }
        public bool IsDeleted { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? CustomerId { get; set; }
        public int? GroupId { get; set; }
        public string JobGroup { get; set; }
        public string JobGroupCode { get; set; }
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
        public int IsMedicalExpired { get; set; }
        public int? BaseAirportId { get; set; }
        public string CurrentLocationCity { get; set; }
        public int? CurrentLocationCityId { get; set; }
        public int AvStatusId { get; set; }
        public string AvStatus { get; set; }
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
        public int? RemainFirstAid { get; set; }
        public int IsPassportExpired { get; set; }
        public int IsProficiencyExpired { get; set; }
        public int IsSEPTExpired { get; set; }
        public int IsSEPTPExpired { get; set; }
        public int IsSMSExpired { get; set; }
        public int IsUpsetRecoveryTrainingExpired { get; set; }
        public int? RemainAvSec { get; set; }
        public int? RemainCAO { get; set; }
        public int? RemainCCRM { get; set; }
        public int? RemainCMC { get; set; }
        public int? RemainColdWeather { get; set; }
        public int? RemainCRM { get; set; }
        public int? RemainDG { get; set; }
        public int? RemainHotWeather { get; set; }
        public int? RemainLicence { get; set; }
        public int? RemainLicenceIR { get; set; }
        public int? RemainLPR { get; set; }
        public int? RemainMedical { get; set; }
        public int? RemainPassport { get; set; }
        public int? RemainProficiency { get; set; }
        public int? RemainSEPT { get; set; }
        public int? RemainSEPTP { get; set; }
        public int? RemainSMS { get; set; }
        public int? RemainUpsetRecoveryTraining { get; set; }
        public string ScheduleName { get; set; }
        public string Code { get; set; }
        public string SecretCode { get; set; }
        public int GroupOrder { get; set; }
        public bool? IsValid { get; set; }
        public DateTime DateInactiveBegin { get; set; }
        public DateTime DateInactiveEnd { get; set; }
        public int IsCockpit { get; set; }
        public int IsCabin { get; set; }
    }
}
