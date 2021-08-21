using System;
using System.Collections.Generic;

#nullable disable

namespace APCore.Models
{
    public partial class _WeatherTafADD
    {
        public int Id { get; set; }
        public DateTime DateCreate { get; set; }
        public string StationId { get; set; }
        public string RawText { get; set; }
        public DateTime? IssueTime { get; set; }
        public DateTime? BulletinTime { get; set; }
        public DateTime? ValidTimeFrom { get; set; }
        public DateTime? ValidTimeTo { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? EvaluationM { get; set; }
        public string Remarks { get; set; }
    }
}
