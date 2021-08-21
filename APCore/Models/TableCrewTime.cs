using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class TableCrewTime
    {
        public int Id { get; set; }
        public double? Day1_Flight { get; set; }
        public double? Day7_Flight { get; set; }
        public double? Day14_Flight { get; set; }
        public double? Day28_Flight { get; set; }
        public double? Year_Flight { get; set; }
        public double? CYear_Flight { get; set; }
        public double? Day1_Duty { get; set; }
        public double? Day14_Duty { get; set; }
        public double? Day28_Duty { get; set; }
        public DateTime CDate { get; set; }
        public double? Day7_Duty { get; set; }
    }
}
