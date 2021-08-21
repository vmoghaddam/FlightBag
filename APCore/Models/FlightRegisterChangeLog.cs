using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class FlightRegisterChangeLog
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public int OldRegisterId { get; set; }
        public int NewRegisterId { get; set; }
        public DateTime Date { get; set; }
        public int? UserId { get; set; }
        public int ReasonId { get; set; }
        public string Remark { get; set; }
    }
}
