using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewFlightPlanCalanderCrew
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int? CalanderId { get; set; }
        public int? FlightPlanId { get; set; }
        public int GroupId { get; set; }
        public int? AvStatusId { get; set; }
        public string AvStatus { get; set; }
        public string JobGroup { get; set; }
        public string JobGroupCode { get; set; }
        public string Remark { get; set; }
        public int? BoxId { get; set; }
        public int? FlightPlanItemId { get; set; }
        public string PID { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int PersonId { get; set; }
        public DateTime? DateJoinCompany { get; set; }
        public int? ExpCompany { get; set; }
        public DateTime? DateRegister { get; set; }
        public DateTime? DateConfirmed { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Username { get; set; }
        public int? CustomerId { get; set; }
        public int MarriageId { get; set; }
        public string NID { get; set; }
        public int SexId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateBirth { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string FaxTelNumber { get; set; }
        public string PassportNumber { get; set; }
        public DateTime? DatePassportExpire { get; set; }
        public DateTime? DatePassportIssue { get; set; }
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
        public string PPLNumber { get; set; }
        public DateTime? PPLDateIssue { get; set; }
        public DateTime? PPLDateExpire { get; set; }
        public int? PPLExpireStatus { get; set; }
        public string CPLNumber { get; set; }
        public DateTime? CPLDateIssue { get; set; }
        public DateTime? CPLDateExpire { get; set; }
        public int? CPLExpireStatus { get; set; }
        public string ATPLNumber { get; set; }
        public DateTime? ATPLDateIssue { get; set; }
        public DateTime? ATPLDateExpire { get; set; }
        public int? ATPLExpireStatus { get; set; }
        public string MCCNumber { get; set; }
        public DateTime? MCCDateIssue { get; set; }
        public DateTime? MCCDateExpire { get; set; }
        public int? MCCExpireStatus { get; set; }
        public int? CurrentLocationAirportId { get; set; }
        public string CurrentLocationAirporIATA { get; set; }
        public int IsMedicalExpired { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public int? FromAirportId { get; set; }
        public int? ToAirportId { get; set; }
        public string Flights { get; set; }
        public DateTime? Date { get; set; }
        public string FromAirportIATA { get; set; }
        public string ToAirportIATA { get; set; }
    }
}
