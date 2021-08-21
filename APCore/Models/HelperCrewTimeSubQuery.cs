using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class HelperCrewTimeSubQuery
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
    }
}
