using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class PersonEducation
    {
        public PersonEducation()
        {
            PersonEducationDocuments = new HashSet<PersonEducationDocument>();
        }

        public int Id { get; set; }
        public int PersonId { get; set; }
        public int EducationDegreeId { get; set; }
        public DateTime? DateCatch { get; set; }
        public string College { get; set; }
        public string Remark { get; set; }
        public string Title { get; set; }
        public int StudyFieldId { get; set; }
        public string FileTitle { get; set; }
        public string FileType { get; set; }
        public string FileUrl { get; set; }
        public string SysUrl { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<PersonEducationDocument> PersonEducationDocuments { get; set; }
    }
}
