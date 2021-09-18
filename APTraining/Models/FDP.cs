using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class FDP
    {
        public FDP()
        {
            CourseSessionFDPs = new HashSet<CourseSessionFDP>();
            CrewPickupSMs = new HashSet<CrewPickupSM>();
            EmployeeCalendars = new HashSet<EmployeeCalendar>();
            ExtensionHistories = new HashSet<ExtensionHistory>();
            FDPItems = new HashSet<FDPItem>();
            IdeaSessionItems = new HashSet<IdeaSessionItem>();
            InverseFDPNavigation = new HashSet<FDP>();
            OffItems = new HashSet<OffItem>();
        }

        public int Id { get; set; }
        public int? CrewId { get; set; }
        public DateTime? ReportingTime { get; set; }
        public DateTime? DelayedReportingTime { get; set; }
        public DateTime? RevisedDelayedReportingTime { get; set; }
        public DateTime? FirstNotification { get; set; }
        public DateTime? NextNotification { get; set; }
        public int? DelayAmount { get; set; }
        public int? BoxId { get; set; }
        public int? JobGroupId { get; set; }
        public bool IsTemplate { get; set; }
        public int DutyType { get; set; }
        public DateTime? DateContact { get; set; }
        public int? FDPId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public int? CityId { get; set; }
        public int? TemplateId { get; set; }
        public DateTime? FDPReportingTime { get; set; }
        public Guid? GUID { get; set; }
        public int? FirstFlightId { get; set; }
        public int? LastFlightId { get; set; }
        public int? UPD { get; set; }
        public bool? IsMain { get; set; }
        public string Key { get; set; }
        public bool? CP { get; set; }
        public int? CustomerId { get; set; }
        public string Remark { get; set; }
        public int? LocationId { get; set; }
        public DateTime? InitStart { get; set; }
        public DateTime? InitEnd { get; set; }
        public DateTime? InitRestTo { get; set; }
        public string InitFlts { get; set; }
        public string InitRoute { get; set; }
        public string InitFromIATA { get; set; }
        public string InitToIATA { get; set; }
        public string InitNo { get; set; }
        public string InitKey { get; set; }
        public int? InitHomeBase { get; set; }
        public string InitRank { get; set; }
        public int? InitIndex { get; set; }
        public string InitGroup { get; set; }
        public string InitScheduleName { get; set; }
        public string InitFlights { get; set; }
        public string Remark2 { get; set; }
        public string CanceledNo { get; set; }
        public string CanceledRoute { get; set; }
        public int? Extension { get; set; }
        public double? Split { get; set; }
        public DateTime? DateConfirmed { get; set; }
        public string ConfirmedBy { get; set; }
        public string UserName { get; set; }

        public virtual Box Box { get; set; }
        public virtual Employee Crew { get; set; }
        public virtual FDP FDPNavigation { get; set; }
        public virtual ICollection<CourseSessionFDP> CourseSessionFDPs { get; set; }
        public virtual ICollection<CrewPickupSM> CrewPickupSMs { get; set; }
        public virtual ICollection<EmployeeCalendar> EmployeeCalendars { get; set; }
        public virtual ICollection<ExtensionHistory> ExtensionHistories { get; set; }
        public virtual ICollection<FDPItem> FDPItems { get; set; }
        public virtual ICollection<IdeaSessionItem> IdeaSessionItems { get; set; }
        public virtual ICollection<FDP> InverseFDPNavigation { get; set; }
        public virtual ICollection<OffItem> OffItems { get; set; }
    }
}
