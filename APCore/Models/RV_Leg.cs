using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class RV_Leg
    {
        public string DateUTC { get; set; }
        public string FltNo { get; set; }
        public string DepStn { get; set; }
        public string ArrStn { get; set; }
        public string DepTime { get; set; }
        public string ArrTime { get; set; }
        public string DepTimeLCL { get; set; }
        public string ArrTimeLCL { get; set; }
        public string STD { get; set; }
        public string STA { get; set; }
        public string STC { get; set; }
        public string ACType { get; set; }
        public string ACReg { get; set; }
    }
}
