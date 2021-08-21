using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class CaoType
    {
        public CaoType()
        {
            CaoBasicTypes = new HashSet<CaoBasicType>();
            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        public int? AircraftTypeId { get; set; }
        public string Title { get; set; }
        public string CaoGroup { get; set; }
        public string Remark { get; set; }

        public virtual AircraftType AircraftType { get; set; }
        public virtual ICollection<CaoBasicType> CaoBasicTypes { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
