using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewBook
    {
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
        public string Category { get; set; }
        public string Publisher { get; set; }
        public string PublisherWebsite { get; set; }
        public DateTime? DateCreate { get; set; }
        public string Abstract { get; set; }
        public string ImageUrl { get; set; }
        public int? FolderId { get; set; }
        public string FullCode { get; set; }
        public string Keywords { get; set; }
        public string AuthorIds { get; set; }
        public string Authors { get; set; }
        public string TranslatorIds { get; set; }
        public DateTime? DateExposure { get; set; }
        public int IsExposed { get; set; }
        public string No { get; set; }
        public string Sender { get; set; }
        public string DateConference { get; set; }
        public int? ConferenceLocationId { get; set; }
        public string Conference { get; set; }
        public int? JournalId { get; set; }
        public int TypeId { get; set; }
        public int? NumberOfLessens { get; set; }
        public string ExternalUrl { get; set; }
        public string Duration { get; set; }
        public int? LanguageId { get; set; }
        public DateTime? DateDeadline { get; set; }
        public string Language { get; set; }
        public string Type { get; set; }
        public string Journal { get; set; }
        public string PublishedIn { get; set; }
        public string INSPECAccessionNumber { get; set; }
        public string DateEffective { get; set; }
        public string Edition { get; set; }
        public DateTime? DeadLine { get; set; }
        public int? RemainingDeadLine { get; set; }
        public DateTime? DateValidUntil { get; set; }
        public int? RemainingValid { get; set; }
        public int? Total { get; set; }
        public int? Visited { get; set; }
        public int? NotVisited { get; set; }
        public int? Downloaded { get; set; }
        public int? NotDownloaded { get; set; }
        public int? FileCount { get; set; }
        public int? Issue { get; set; }
    }
}
