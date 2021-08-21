using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class NOTAM
    {
        public NOTAM()
        {
            NOTAMItems = new HashSet<NOTAMItem>();
        }

        public int Id { get; set; }
        public DateTime? DateCreate { get; set; }
        public int? FlightId { get; set; }
        public int? FDPId { get; set; }
        public string StationId { get; set; }
        public DateTime? DateDay { get; set; }

        public virtual ICollection<NOTAMItem> NOTAMItems { get; set; }
    }
}
