using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class LogProp
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string PropName { get; set; }
        public string PropValue { get; set; }
        public DateTime? DateUpdate { get; set; }
        public decimal? DateUpdateLocal { get; set; }
        public string User { get; set; }
        public string PropValueOld { get; set; }
    }
}
