using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewCrewDutyNoReg
    {
        public int Id { get; set; }
        public int CrewId { get; set; }
        public string Name { get; set; }
        public string ScheduleName { get; set; }
        public string Mobile { get; set; }
        public string JobGroup { get; set; }
        public int? GroupId { get; set; }
        public string JobGroupCode { get; set; }
        public int IsCockpit { get; set; }
        public int IsCabin { get; set; }
        public DateTime? DateLocal { get; set; }
        public string FltNo { get; set; }
        public string Route { get; set; }
        public int DutyType { get; set; }
        public string DutyTypeTitle { get; set; }
        public DateTime? STDLocal { get; set; }
        public DateTime? STALocal { get; set; }
        public DateTime? DateStartLocal { get; set; }
        public DateTime? DateEndLocal { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public DateTime? StartUTC { get; set; }
        public DateTime? EndUTC { get; set; }
        public string REgister { get; set; }
        public string AircraftType { get; set; }
        public string Remark { get; set; }
        public int OrderIndex { get; set; }
        public int? DateStartYear { get; set; }
        public int? DateStartMonth { get; set; }
        public int? DateStartDay { get; set; }
        public DateTime? RestUntil { get; set; }
        public DateTime? RestUntilLocal { get; set; }
        public string Remark2 { get; set; }
        public string InitFlts { get; set; }
        public string InitRoute { get; set; }
        public string CanceledNo { get; set; }
        public string CanceledRoute { get; set; }
        public double ExtendedBySplitDuty { get; set; }
        public int IsExtendedBySplitDuty { get; set; }
        public double? MaxFDPExtended { get; set; }
        public double? DutyScheduled { get; set; }
        public double? Duty { get; set; }
        public int? IsOver { get; set; }
        public int? Extension { get; set; }
        public int IsExtension { get; set; }
        public DateTime? DateConfirmed { get; set; }
        public string ConfirmedBy { get; set; }
        public int IsConfirmed { get; set; }
        public string UserName { get; set; }
        public string Ref { get; set; }
        public int? ResId { get; set; }
        public string ResStr { get; set; }
        public DateTime? ResDate { get; set; }
        public string Delivery { get; set; }
        public int? SMSId { get; set; }
        public string SMS { get; set; }
        public DateTime? DateSent { get; set; }
        public DateTime? DateVisit { get; set; }
        public int IsVisited { get; set; }
        public string IsVisitedStr { get; set; }
    }
}
