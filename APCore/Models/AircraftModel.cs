using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class AircraftModel
    {
        public AircraftModel()
        {
            Ac_MSNs = new HashSet<Ac_MSN>();
            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string Model { get; set; }
        public int AircraftTypeId { get; set; }
        public string Remark { get; set; }

        public virtual AircraftType AircraftType { get; set; }
        public virtual ICollection<Ac_MSN> Ac_MSNs { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
