using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewRosterReport
    {
        public int Id { get; set; }
        public DateTime? DateLocal { get; set; }
        public string FltNo { get; set; }
        public string Route { get; set; }
        public DateTime? STDLocal { get; set; }
        public DateTime? STALocal { get; set; }
        public string Register { get; set; }
        public string AircraftType { get; set; }
        public string IP { get; set; }
        public string OBS { get; set; }
        public string P1 { get; set; }
        public string P2 { get; set; }
        public string SAFETY { get; set; }
        public string SCCM { get; set; }
        public string CCM1 { get; set; }
        public string CCM2 { get; set; }
        public string CCM3 { get; set; }
    }
}
