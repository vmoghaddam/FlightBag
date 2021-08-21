using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewFlightDelayCode
    {
        public int FlightId { get; set; }
        public int? FlighrDelayId { get; set; }
        public int? HH { get; set; }
        public int? MM { get; set; }
        public int? UserId { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int DelayCategoryId { get; set; }
        public int? AirlineId { get; set; }
        public int DelayCodeId { get; set; }
        public int Selected { get; set; }
        public string Remark { get; set; }
    }
}
