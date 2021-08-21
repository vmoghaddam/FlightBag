using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class NiraHistory
    {
        public int Id { get; set; }
        public string FLIGHT { get; set; }
        public string CHTIME { get; set; }
        public string NEWAIRCRAFT { get; set; }
        public string NEWSTATUS { get; set; }
        public DateTime? DateSend { get; set; }
        public DateTime? DateReplied { get; set; }
        public string Remark { get; set; }
        public int? FlightId { get; set; }
        public int? FlightStatusId { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? Arrival { get; set; }
        public string Register { get; set; }
    }
}
