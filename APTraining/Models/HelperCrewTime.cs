using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class HelperCrewTime
    {
        public int Id { get; set; }
        public DateTime CDate { get; set; }
        public double Duration { get; set; }
        public double DurationLocal { get; set; }
    }
}
