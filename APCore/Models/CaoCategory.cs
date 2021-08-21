using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class CaoCategory
    {
        public CaoCategory()
        {
            PersonCaoLicenceHistories = new HashSet<PersonCaoLicenceHistory>();
            PersonCaoLicenses = new HashSet<PersonCaoLicense>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<PersonCaoLicenceHistory> PersonCaoLicenceHistories { get; set; }
        public virtual ICollection<PersonCaoLicense> PersonCaoLicenses { get; set; }
    }
}
