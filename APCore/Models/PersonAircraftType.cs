using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class PersonAircraftType
    {
        public int Id { get; set; }
        public int AircraftTypeId { get; set; }
        public int PersonId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateLimitBegin { get; set; }
        public DateTime? DateLimitEnd { get; set; }
        public string Remark { get; set; }

        public virtual AircraftType AircraftType { get; set; }
        public virtual Person Person { get; set; }
    }
}
