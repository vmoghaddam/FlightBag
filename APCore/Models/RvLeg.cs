using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class RvLeg
    {
        public string DateUtc { get; set; }
        public string FltNo { get; set; }
        public string DepStn { get; set; }
        public string ArrStn { get; set; }
        public string DepTime { get; set; }
        public string ArrTime { get; set; }
        public string DepTimeLcl { get; set; }
        public string ArrTimeLcl { get; set; }
        public string Std { get; set; }
        public string Sta { get; set; }
        public string Stc { get; set; }
        public string Actype { get; set; }
        public string Acreg { get; set; }
    }
}
