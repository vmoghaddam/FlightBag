using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class PersonCaoLicenceHistory
    {
        public int Id { get; set; }
        public int CaoUserLicenseId { get; set; }
        public int PersonId { get; set; }
        public int CaoBasicTypeId { get; set; }
        public int CaoCategoryId { get; set; }
        public DateTime DateLicense { get; set; }
        public string Remark { get; set; }

        public virtual CaoBasicType CaoBasicType { get; set; }
        public virtual CaoCategory CaoCategory { get; set; }
        public virtual PersonCaoLicense CaoUserLicense { get; set; }
        public virtual Person Person { get; set; }
    }
}
