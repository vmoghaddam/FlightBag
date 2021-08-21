using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewCrewCertificatesSummary
    {
        public string Name { get; set; }
        public string JobGroup { get; set; }
        public string JobGroupCode { get; set; }
        public DateTime? MedicalLastCheckup { get; set; }
        public DateTime? MedicalNextChechup { get; set; }
        public int IsMedicalExpired { get; set; }
        public int? RemainMedical { get; set; }
        public DateTime? LPRExpireDate { get; set; }
        public int IsLPRExpired { get; set; }
        public int? RemainLPR { get; set; }
        public DateTime? ProficiencyCheckDate { get; set; }
        public DateTime? ProficiencyExpireDate { get; set; }
        public int? RemainProficiency { get; set; }
        public int IsProficiencyExpired { get; set; }
        public DateTime? CMCExpireDate { get; set; }
        public int? RemainCMC { get; set; }
        public int IsCMCExpired { get; set; }
        public DateTime? CCRMIssueDate { get; set; }
        public DateTime? CCRMExpireDate { get; set; }
        public int? RemainCCRM { get; set; }
        public int IsCCRMExpired { get; set; }
        public DateTime? AvSecIssueDate { get; set; }
        public DateTime? AvSecExpireDate { get; set; }
        public int? RemainAvSec { get; set; }
        public int IsAvSecExpired { get; set; }
        public DateTime? SEPTIssueDate { get; set; }
        public DateTime? SEPTExpireDate { get; set; }
        public int? RemainSEPT { get; set; }
        public int IsSEPTExpired { get; set; }
        public DateTime? SEPTPracticalIssueDate { get; set; }
        public DateTime? SEPTPracticalExpireDate { get; set; }
        public int? RemainSEPTP { get; set; }
        public int IsSEPTPExpired { get; set; }
        public DateTime? DGIssueDate { get; set; }
        public DateTime? DGExpireDate { get; set; }
        public int? RemainDG { get; set; }
        public int IsDGExpired { get; set; }
        public DateTime? SMSIssueDate { get; set; }
        public DateTime? SMSExpireDate { get; set; }
        public int? RemainSMS { get; set; }
        public int IsSMSExpired { get; set; }
        public DateTime? FirstAidIssueDate { get; set; }
        public DateTime? FirstAidExpireDate { get; set; }
        public int? RemainFirstAid { get; set; }
        public int IsFirstAidExpired { get; set; }
        public DateTime? ColdWeatherIssueDate { get; set; }
        public DateTime? ColdWeatherExpireDate { get; set; }
        public int? RemainColdWeather { get; set; }
        public int IsColdWeatherExpired { get; set; }
        public DateTime? HotWeatherIssueDate { get; set; }
        public DateTime? HotWeatherExpireDate { get; set; }
        public int? RemainHotWeather { get; set; }
        public int IsHotWeatherExpired { get; set; }
    }
}
