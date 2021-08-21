using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class FlightStatus
    {
        public FlightStatus()
        {
            FlightInformations = new HashSet<FlightInformation>();
        }

        public int ID { get; set; }
        public string FlightStatus1 { get; set; }
        public string Description { get; set; }
        public string BgColor { get; set; }
        public string Color { get; set; }
        public string Class { get; set; }

        public virtual ICollection<FlightInformation> FlightInformations { get; set; }
    }
}
