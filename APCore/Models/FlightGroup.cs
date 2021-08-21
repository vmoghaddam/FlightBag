using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class FlightGroup
    {
        public FlightGroup()
        {
            FlightInformations = new HashSet<FlightInformation>();
        }

        public int ID { get; set; }
        public int EmployeeId { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string Remark { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ICollection<FlightInformation> FlightInformations { get; set; }
    }
}
