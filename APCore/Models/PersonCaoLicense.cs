using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class PersonCaoLicense
    {
        public PersonCaoLicense()
        {
            PersonCaoLicenceHistories = new HashSet<PersonCaoLicenceHistory>();
        }

        public int Id { get; set; }
        public int PersonId { get; set; }
        public int? CaoBasicTypeId { get; set; }
        public int? CaoCategoryId { get; set; }
        public int? CaoBasicId { get; set; }
        public DateTime? DateLicense { get; set; }
        public string Remark { get; set; }
        public string Result { get; set; }
        public bool? IsNew { get; set; }
        public bool? Quarantine { get; set; }

        public virtual CaoBasic CaoBasic { get; set; }
        public virtual CaoBasicType CaoBasicType { get; set; }
        public virtual CaoCategory CaoCategory { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<PersonCaoLicenceHistory> PersonCaoLicenceHistories { get; set; }
    }
}
