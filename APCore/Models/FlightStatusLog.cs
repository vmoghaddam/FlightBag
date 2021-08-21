using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class FlightStatusLog
    {
        public int ID { get; set; }
        public int FlightID { get; set; }
        public int FlightStatusID { get; set; }
        public DateTime Date { get; set; }
        public string Remark { get; set; }
        public int UserId { get; set; }

        public virtual FlightInformation Flight { get; set; }
    }
}
