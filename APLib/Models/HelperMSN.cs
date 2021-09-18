using System;
using System.Collections.Generic;

#nullable disable

namespace APLib.Models
{
    public partial class HelperMSN
    {
        public int ID { get; set; }
        public int? AC_ModelID { get; set; }
        public int? TypeId { get; set; }
        public string Type { get; set; }
        public int? TotalSeat { get; set; }
        public int? MSN { get; set; }
        public string Register { get; set; }
    }
}
