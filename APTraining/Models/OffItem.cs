using System;
using System.Collections.Generic;

#nullable disable

namespace APTraining.Models
{
    public partial class OffItem
    {
        public int FDPId { get; set; }
        public int FlightId { get; set; }
        public string Remark { get; set; }

        public virtual FDP FDP { get; set; }
        public virtual FlightInformation Flight { get; set; }
    }
}
