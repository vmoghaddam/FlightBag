using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class Document
    {
        public Document()
        {
            BookFiles = new HashSet<BookFile>();
            InverseParent = new HashSet<Document>();
            PersonEducationDocuments = new HashSet<PersonEducationDocument>();
            PersonRatingDocuments = new HashSet<PersonRatingDocument>();
        }

        public int Id { get; set; }
        public int? DocumentTypeId { get; set; }
        public int? FileTypeId { get; set; }
        public string FileUrl { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public string SysUrl { get; set; }
        public string FileType { get; set; }

        public virtual Document Parent { get; set; }
        public virtual PersonDocumentFile PersonDocumentFile { get; set; }
        public virtual ICollection<BookFile> BookFiles { get; set; }
        public virtual ICollection<Document> InverseParent { get; set; }
        public virtual ICollection<PersonEducationDocument> PersonEducationDocuments { get; set; }
        public virtual ICollection<PersonRatingDocument> PersonRatingDocuments { get; set; }
    }
}
