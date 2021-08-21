using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class AppLegHelper
    {
        public int ID { get; set; }
        public DateTime? STDDay { get; set; }
        public string IPName { get; set; }
        public int? IPId { get; set; }
        public string IPScheduleName { get; set; }
        public string P1Name { get; set; }
        public int? P1Id { get; set; }
        public string P1ScheduleName { get; set; }
        public string P2Name { get; set; }
        public int? P2Id { get; set; }
        public string P2ScheduleName { get; set; }
        public string PIC { get; set; }
        public int? PICId { get; set; }
        public string SIC { get; set; }
        public int? SICId { get; set; }
    }
}
