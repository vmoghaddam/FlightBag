using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class DelayCode
    {
        public DelayCode()
        {
            FlightDelays = new HashSet<FlightDelay>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int DelayCategoryId { get; set; }
        public string Remark { get; set; }
        public int? AirlineId { get; set; }
        public string ICategory { get; set; }

        public virtual DelayCodeCategory DelayCategory { get; set; }
        public virtual ICollection<FlightDelay> FlightDelays { get; set; }
    }
}
