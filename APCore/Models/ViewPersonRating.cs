using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class ViewPersonRating
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int AircraftTypeId { get; set; }
        public int? RatingId { get; set; }
        public DateTime DateIssue { get; set; }
        public DateTime? DateExpire { get; set; }
        public int? CategoryId { get; set; }
        public string AircraftType { get; set; }
        public string RatingOrganization { get; set; }
        public int? OrganizationId { get; set; }
        public string Category { get; set; }
    }
}
