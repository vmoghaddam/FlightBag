using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class LicenseResultBasic
    {
        public LicenseResultBasic()
        {
            CourseTypes = new HashSet<CourseType>();
        }

        public int Id { get; set; }
        public bool Airframe { get; set; }
        public bool PowerPlant { get; set; }
        public bool Electronics { get; set; }
        public bool Electric { get; set; }
        public string Result { get; set; }
        public bool? IsNew { get; set; }

        public virtual ICollection<CourseType> CourseTypes { get; set; }
    }
}
