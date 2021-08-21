using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class CaoBasicType
    {
        public CaoBasicType()
        {
            PersonCaoLicenceHistories = new HashSet<PersonCaoLicenceHistory>();
            PersonCaoLicenses = new HashSet<PersonCaoLicense>();
        }

        public int Id { get; set; }
        public int CaoBasicId { get; set; }
        public int CaoTypeId { get; set; }

        public virtual CaoBasic CaoBasic { get; set; }
        public virtual CaoType CaoType { get; set; }
        public virtual ICollection<PersonCaoLicenceHistory> PersonCaoLicenceHistories { get; set; }
        public virtual ICollection<PersonCaoLicense> PersonCaoLicenses { get; set; }
    }
}
