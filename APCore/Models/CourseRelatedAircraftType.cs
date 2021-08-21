using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class CourseRelatedAircraftType
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int AircraftTypeId { get; set; }
        public string Remark { get; set; }

        public virtual AircraftType AircraftType { get; set; }
        public virtual Course Course { get; set; }
    }
}
