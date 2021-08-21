using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewDutyFDPDetail
    {
        public DateTime CDate { get; set; }
        public int? CDay { get; set; }
        public DateTime? DatePart { get; set; }
        public int FDPId { get; set; }
        public int? CrewId { get; set; }
        public int? PositionId { get; set; }
        public string Position { get; set; }
        public DateTime? DutyStart { get; set; }
        public DateTime? DutyEnd { get; set; }
        public DateTime? DutyStartLocal { get; set; }
        public DateTime? DutyEndLocal { get; set; }
        public int? DateStartYear { get; set; }
        public int? DateStartMonth { get; set; }
        public int? DateStartDay { get; set; }
        public int? DateEndDay { get; set; }
        public int? DateEndMonth { get; set; }
        public string FDPTitle { get; set; }
        public string FDPRemark { get; set; }
        public string DutyTypeTitle { get; set; }
        public int DutyType { get; set; }
        public string JobGroup { get; set; }
        public int? GroupId { get; set; }
        public string JobGroupCode { get; set; }
        public double? Duration { get; set; }
        public double? DurationLocal { get; set; }
        public int? TemplateId { get; set; }
        public string ScheduleName { get; set; }
        public int? MaleFemaleError { get; set; }
        public int? MatchingListErrors { get; set; }
    }
}
