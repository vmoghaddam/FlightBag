using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class Book
    {
        public Book()
        {
            BookAutors = new HashSet<BookAutor>();
            BookChapters = new HashSet<BookChapter>();
            BookFiles = new HashSet<BookFile>();
            BookKeywords = new HashSet<BookKeyword>();
            BookRelatedAircraftTypes = new HashSet<BookRelatedAircraftType>();
            BookRelatedEmployees = new HashSet<BookRelatedEmployee>();
            BookRelatedGroups = new HashSet<BookRelatedGroup>();
            BookRelatedStudyFields = new HashSet<BookRelatedStudyField>();
            Chapters = new HashSet<Chapter>();
            EmployeeBookStatuses = new HashSet<EmployeeBookStatus>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime? DateRelease { get; set; }
        public int? PublisherId { get; set; }
        public string ISSNPrint { get; set; }
        public string ISSNElectronic { get; set; }
        public string DOI { get; set; }
        public string Pages { get; set; }
        public int CategoryId { get; set; }
        public int? CustomerId { get; set; }
        public string Abstract { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DatePublished { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? DateDeadline { get; set; }
        public string Duration { get; set; }
        public int? LanguageId { get; set; }
        public string ExternalUrl { get; set; }
        public int? NumberOfLessens { get; set; }
        public int TypeId { get; set; }
        public int? JournalId { get; set; }
        public string Conference { get; set; }
        public int? ConferenceLocationId { get; set; }
        public string DateConference { get; set; }
        public string Sender { get; set; }
        public string No { get; set; }
        public string PublishedIn { get; set; }
        public string INSPECAccessionNumber { get; set; }
        public string Edition { get; set; }
        public string DateEffective { get; set; }
        public int? FolderId { get; set; }
        public int? Issue { get; set; }
        public DateTime? DeadLine { get; set; }
        public DateTime? DateValidUntil { get; set; }
        public string BookKey { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Organization Publisher { get; set; }
        public virtual ICollection<BookAutor> BookAutors { get; set; }
        public virtual ICollection<BookChapter> BookChapters { get; set; }
        public virtual ICollection<BookFile> BookFiles { get; set; }
        public virtual ICollection<BookKeyword> BookKeywords { get; set; }
        public virtual ICollection<BookRelatedAircraftType> BookRelatedAircraftTypes { get; set; }
        public virtual ICollection<BookRelatedEmployee> BookRelatedEmployees { get; set; }
        public virtual ICollection<BookRelatedGroup> BookRelatedGroups { get; set; }
        public virtual ICollection<BookRelatedStudyField> BookRelatedStudyFields { get; set; }
        public virtual ICollection<Chapter> Chapters { get; set; }
        public virtual ICollection<EmployeeBookStatus> EmployeeBookStatuses { get; set; }
    }
}
