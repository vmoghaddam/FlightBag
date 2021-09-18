﻿using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class ViewFDPRest
    {
        public int Id { get; set; }
        public int? CrewId { get; set; }
        public int? JobGroupId { get; set; }
        public string JobGroup { get; set; }
        public int? BoxId { get; set; }
        public int? Sectors { get; set; }
        public int? ACTypeId { get; set; }
        public string FromAirport { get; set; }
        public string FromAirportIATA { get; set; }
        public int? FromAirportId { get; set; }
        public int? FromAirportCityId { get; set; }
        public int? CityId { get; set; }
        public int? FDPLocationId { get; set; }
        public string ToAirport { get; set; }
        public string ToAirportIATA { get; set; }
        public int? ToAirportId { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public DateTime? STDLocal { get; set; }
        public DateTime? STALocal { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? Arrival { get; set; }
        public DateTime? DepartureLocal { get; set; }
        public DateTime? ArrivalLocal { get; set; }
        public DateTime? DefaultReportingTime { get; set; }
        public DateTime? DefaultReportingTimeLocal { get; set; }
        public DateTime? ReportingTime { get; set; }
        public DateTime? ReportingTimeLocal { get; set; }
        public int? FDPScheduled { get; set; }
        public int? FDP { get; set; }
        public double? DutyScheduled { get; set; }
        public double? Duty { get; set; }
        public DateTime? FDPStart { get; set; }
        public DateTime? FDPStartLocal { get; set; }
        public DateTime? FDPEnd { get; set; }
        public DateTime? FDPEndLocal { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DutyStart { get; set; }
        public DateTime? DateStartLocal { get; set; }
        public DateTime? DutyStartLocal { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime? DutyEnd { get; set; }
        public DateTime? DateEndLocal { get; set; }
        public DateTime? DutyEndLocal { get; set; }
        public double DelayAmount { get; set; }
        public DateTime? DelayedReportingTime { get; set; }
        public DateTime? NextNotification { get; set; }
        public DateTime? RevisedDelayedReportingTime { get; set; }
        public DateTime? FirstNotification { get; set; }
        public double? MaxFDP { get; set; }
        public double? MaxFDPExtended { get; set; }
        public int IsDutyOver { get; set; }
        public int ExtendedBySplitDuty { get; set; }
        public int? StandById { get; set; }
        public DateTime? StandByStart { get; set; }
        public DateTime? StandByStartLocal { get; set; }
        public int? StandByDuration { get; set; }
        public int? FDPStandByScheduled { get; set; }
        public int? FDPStandby { get; set; }
        public int FDPStandByScheduledError { get; set; }
        public int FDPStandbyError { get; set; }
        public double? FDPReductionByStandBy { get; set; }
        public bool IsTemplate { get; set; }
        public DateTime? DateContact { get; set; }
        public DateTime? DateContactLocal { get; set; }
        public int DutyType { get; set; }
        public string DutyTypeTitle { get; set; }
        public DateTime? RestUntil { get; set; }
        public DateTime? RestUntilLocal { get; set; }
        public int? LocationId { get; set; }
        public string Location { get; set; }
        public DateTime? DaySTDLocal { get; set; }
        public int? FDPId { get; set; }
        public int? DateStartYear { get; set; }
        public int? DateStartMonth { get; set; }
        public int? DateStartDay { get; set; }
        public int? TemplateId { get; set; }
        public string Remark { get; set; }
        public string Remark2 { get; set; }
        public string InitFlts { get; set; }
        public string InitRoute { get; set; }
        public string CanceledNo { get; set; }
        public string CanceledRoute { get; set; }
        public int? Extension { get; set; }
        public int IsExtension { get; set; }
        public DateTime? DateConfirmed { get; set; }
        public string ConfirmedBy { get; set; }
        public int IsConfirmed { get; set; }
        public string UserName { get; set; }
        public int? UPD { get; set; }
        public int? CustomerId { get; set; }
    }
}
