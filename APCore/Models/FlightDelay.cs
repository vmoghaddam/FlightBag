using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class FlightDelay
    {
        public int ID { get; set; }
        public int FlightId { get; set; }
        public int DelayCodeId { get; set; }
        public int? HH { get; set; }
        public int? MM { get; set; }
        public string Remark { get; set; }
        public int? UserId { get; set; }
        public string ICategory { get; set; }

        public virtual DelayCode DelayCode { get; set; }
        public virtual FlightInformation Flight { get; set; }
    }
}
