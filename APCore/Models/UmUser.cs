using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class UmUser
    {
        public string PkUser { get; set; }
        public int? FkGroup { get; set; }
        public int? Fkpost { get; set; }
        public string FkdepartmentsLocation { get; set; }
        public string FkLocationId { get; set; }
        public string FkRootLocation { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string PersonnelId { get; set; }
        public bool? Married { get; set; }
        public string NationalCode { get; set; }
        public string Sex { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Email { get; set; }
        public string EmailPassword { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Mobile { get; set; }
        public string FaxTelNumber { get; set; }
        public string PassportNumber { get; set; }
        public DateTime? PassportIssueDate { get; set; }
        public DateTime? PassportExpireDate { get; set; }
        public string Address { get; set; }
        public bool? Active { get; set; }
        public bool? Competency { get; set; }
        public int? UserName { get; set; }
        public string Password { get; set; }
        public DateTime? DateJoinAvation { get; set; }
        public DateTime? DateJoinCompany { get; set; }
        public DateTime? LastCheckUp { get; set; }
        public DateTime? NextCheckUp { get; set; }
        public DateTime? YearOfExperience { get; set; }
        public string CaoCardNumber { get; set; }
        public DateTime? CompanyIssueDate { get; set; }
        public DateTime? CompanyExpireDate { get; set; }
        public bool? Deleted { get; set; }
        public string RoomNo { get; set; }
        public bool? IsAnbardar { get; set; }
        public bool? IsAnbardarKol { get; set; }
        public bool? IsAnbardarMahdoode { get; set; }
        public bool? IsAminAmval { get; set; }
        public bool? IsAminAmvalKol { get; set; }
        public bool? IsAminAmvalMahdoode { get; set; }
        public bool? IsStockControl { get; set; }
        public bool? IsPurchase { get; set; }
        public bool? IsApprover { get; set; }
        public bool? IsGroupManager { get; set; }
        public bool? IsReceiver { get; set; }
        public bool? IsQc { get; set; }
        public bool? IsRequester { get; set; }
        public bool? IsRepair { get; set; }
        public bool? Admin { get; set; }
        public string Remark { get; set; }
        public string StampNumber { get; set; }
        public string Stamp { get; set; }
        public bool? IsPnApprover { get; set; }
        public string TechLogNo { get; set; }
        public string FkShifts { get; set; }
        public DateTime? IssueDateNdt { get; set; }
        public int? IntervalNdt { get; set; }
        public string Ndtnumber { get; set; }
        public string ICalanderTypeNdt { get; set; }
        public string Nickname { get; set; }
        public bool? IsAuditor { get; set; }
        public bool? IsAuditee { get; set; }
        public string IsQaManager { get; set; }
        public string IsMrfapprover { get; set; }
        public string IsFinancialManager { get; set; }
    }
}
