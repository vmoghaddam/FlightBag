using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewCrewTime
    {
        public int Id { get; set; }
        public string PID { get; set; }
        public string Name { get; set; }
        public DateTime CDate { get; set; }
        public int BoxId { get; set; }
        public string DateStr { get; set; }
        public int Positioning { get; set; }
        public int Day1_Flight { get; set; }
        public int Day7_Flight { get; set; }
        public int Day14_Flight { get; set; }
        public int Day28_Flight { get; set; }
        public int Year_Flight { get; set; }
        public int CYear_Flight { get; set; }
        public double Day1_Duty { get; set; }
        public double Day7_Duty { get; set; }
        public double Day14_Duty { get; set; }
        public double Day28_Duty { get; set; }
        public decimal Year_Duty { get; set; }
        public int CalendarStatusId { get; set; }
        public string CalendarStatus { get; set; }
        public int ECSplitedId { get; set; }
        public int ECId { get; set; }
        public DateTime ECDateStartLocal { get; set; }
        public DateTime ECDateEndLocal { get; set; }
        public DateTime ECDateStart { get; set; }
        public DateTime ECDateEnd { get; set; }
        public int? ECDuty { get; set; }
        public int ECBoxId { get; set; }
        public decimal FDPReduction { get; set; }
        public int Error_Day28_Flight { get; set; }
        public int Error_Year_Flight { get; set; }
        public int Error_CYear_Flight { get; set; }
        public int Error_Day7_Duty { get; set; }
        public int Error_Day14_Duty { get; set; }
        public int Error_Day28_Duty { get; set; }
    }
}
