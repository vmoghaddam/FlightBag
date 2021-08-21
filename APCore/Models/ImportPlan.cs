using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ImportPlan
    {
        public DateTime Date { get; set; }
        public string Base { get; set; }
        public string Type { get; set; }
        public string Reg { get; set; }
        public string No { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime? STD { get; set; }
        public DateTime? STA { get; set; }
        public string Duration { get; set; }
        public string Line { get; set; }
    }
}
