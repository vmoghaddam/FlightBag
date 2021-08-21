using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class CaoBasic
    {
        public CaoBasic()
        {
            CaoBasicTypes = new HashSet<CaoBasicType>();
            PersonCaoLicenses = new HashSet<PersonCaoLicense>();
        }

        public int Id { get; set; }
        public int? CaoBasicLicenseTypeId { get; set; }
        public string Title { get; set; }
        public string CaoGroup { get; set; }
        public string Remark { get; set; }

        public virtual CaoBasicLicenseType CaoBasicLicenseType { get; set; }
        public virtual ICollection<CaoBasicType> CaoBasicTypes { get; set; }
        public virtual ICollection<PersonCaoLicense> PersonCaoLicenses { get; set; }
    }
}
