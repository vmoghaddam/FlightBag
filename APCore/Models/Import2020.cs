using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class IMPORT2020
    {
        public string DATE { get; set; }
        public string FLIGHTNO { get; set; }
        public string FROM { get; set; }
        public string TO { get; set; }
        public string REGISTER { get; set; }
        public string STATUS { get; set; }
        public string ADULT { get; set; }
        public string CHILD { get; set; }
        public string INFANT { get; set; }
        public string TOTAL { get; set; }
        public string BAG { get; set; }
        public string CARGO { get; set; }
        public string STD { get; set; }
        public string STA { get; set; }
        public string TAKEOFF { get; set; }
        public string LANDING { get; set; }
        public string OFFBLOCK { get; set; }
        public string ONBLOCK { get; set; }
        public string UPLIFT { get; set; }
        public string USED { get; set; }
        public int? STATUSID { get; set; }
        public int? REGISTERID { get; set; }
        public int? FROMID { get; set; }
        public int? TOID { get; set; }
    }
}
