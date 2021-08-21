using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class CaoBasicLicenseType
    {
        public CaoBasicLicenseType()
        {
            CaoBasics = new HashSet<CaoBasic>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string ResultTextCatA { get; set; }
        public string ResultTextCatB { get; set; }
        public string ResultTextCatC { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<CaoBasic> CaoBasics { get; set; }
    }
}
